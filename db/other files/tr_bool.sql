create or replace function update_urgency() 
	returns trigger
as $$
declare 
	diff real;
begin

	diff := date_part('hour', old."Дата_приёма"::timestamp - new."Дата_возврата"::timestamp);

	if (diff >  "Услуга"."Длительность_услуги") then
		update "Процесс заказа"
			set "Срочность" = FALSE
			where "Заказ"."Идентификатор" = "Процесс заказа"."Идентификатор_Заказ";
	elsif (diff <= "Услуга"."Длительность_услуги")
		update "Процесс заказа"
			set "Срочность" = TRUE
			where "Заказ"."Идентификатор" = "Процесс заказа"."Идентификатор_Заказ";
	else
		raise exception 'Ошибка при обновлении "Срочность" в таблице "Процесс заказа"!'
	end if;
end;
$$ language 'plpgsql'; 	


create trigger upd_tr 
	after insert or update of "Дата_возврата" on "Заказ" 
	for row 
	execute procedure update_urgency();