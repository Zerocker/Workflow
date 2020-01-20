create or replace function insert_new_discount() 
	returns trigger
as $$
begin
	if not exists (select * from "Расценки" where "Город" = new."Город") then
		raise exception 'Значение "Город" отсутствует в таблице!'
		using hint = 'Заполните необходимые данные в таблицу "Расценки"';
	end if;
	
	if exists (select * from "Расценки" where "Город" = new."Город" and (new."Цена"::float / "Стоимость"::float) > 0.5) then
		raise exception 'Неправильное значение для "Цены скидки"!' 
		using hint = 'Цена скидки должна быть строго меньше стоимости расценки';
	else
		return new;
	end if;
end;
$$ language 'plpgsql'; 	

/*
create trigger ins_tr 
	before insert on "Скидки" 
	for row execute procedure insert_new_discount();
	*/