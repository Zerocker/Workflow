function handleNavbarMenu() {
    let main_nav = document.getElementById("navbar-items");
    let navbar_toggle = document.getElementById("navbar-btn");

    console.log(main_nav);
    console.log(navbar_toggle);

    navbar_toggle.addEventListener("click", function () {
        if (this.classList.contains('active')) {
            main_nav.style.display = "none";
            this.classList.remove("active");
        }
        else {
            main_nav.style.display = "flex";
            this.classList.add('active');
        }
    });
}

function handleAllCheckbox(source) {
    let checkboxes = document.querySelectorAll('input[type=checkbox]');
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i] != source)
            checkboxes[i].checked = source.checked;
    }
	
	let checked = $('input[type=checkbox]:checked').length - 2;
	if (checked == -2)
		checked = 0;
	updateSelected(checked);
}

function formatDT(string)
{
    let d = new Date(string);

    return ("0" + d.getDate()).slice(-2) + "-" + ("0" + (d.getMonth() + 1)).slice(-2) + "-" +
        d.getFullYear() + " " + ("0" + d.getHours()).slice(-2) + ":" + ("0" + d.getMinutes()).slice(-2);

}

function generateSelectedJson(type)
{
    event.preventDefault();
    let data = [{
        "type": type,
    }];
    let table = document.getElementById('brw-directory');

    $('input:checkbox:checked', table).each(function ()
    {
        let id = $(this).closest('tr').attr('id');
        let type = $(this).closest('tr').find('td:nth-child(3)').text();
        let dict = {};
        
        dict["id"] = id;
        dict["name"] = type;
        data.push(dict);

    }).get();

    return JSON.stringify(data);
}

function callInput(actionName)
{
    $('#dd-input-actions').css('display', 'block');
    $('#dd-input-btn').prop('value', actionName);

    $('#dd-input-cls').click(function ()
    {
        $('#dd-input-actions').css('display', 'none');
    });

    if (actionName == "Create")
    {
        $(".dd-input-content").eq(0).css('display', 'block');
        $(".dd-input-content").eq(1).css('display', 'none');

        $("#dd-input-btn").click(function ()
        {
            getCreateFolder();
        });
    }
    else if (actionName == "Rename")
    {
        $(".dd-input-content").eq(0).css('display', 'block');
        $(".dd-input-content").eq(1).css('display', 'none');

        $("#dd-input-btn").click(function ()
        {
            postRename();
        });
    }
    else if (actionName == "Upload")
    {
        $(".dd-input-content").eq(0).css('display', 'none');
        $(".dd-input-content").eq(1).css('display', 'block');
    }
}

// --------------------------------------------
//  Http get requests
// --------------------------------------------
function getContents(id)
{
    id = (id) ? `&id=${id}` : "";

    event.preventDefault();
    $.ajax({
        url: "/Browser/Index?handler=Contents" + id,
        type: "GET",
        dataType: "json",
        success: function (result)
        {
            generateTable(result);
        },
        error: function (errormessage)
        {
            alert("Something wrong with data loading!");
            console.log(errormessage.responseText);
        }
    });
}

function getFile(id)
{
    let file = "/Browser/Index?handler=Download&id=" + id

    event.preventDefault();
    $.ajax({
        url: file,
        type: "GET",
        dataType: "json",
        success: function (result)
        {
            window.location = file;
        },
        error: function (errormessage)
        {
            console.log(errormessage.responseText);
        }
    });
}

function getCreateFolder()
{
    let text = $('#dd-input-txt').val();
    if (text == "")
    {
        alert("Input field is empty!");
        return false;
    }

    $.ajax({
        url: "/Browser/Index?handler=CreateFolder&name=" + text,
        type: "GET",
        dataType: "json",
        success: function (result)
        {
            getContents(result);
            $('#dd-input-actions').css('display', 'none');
        },
        error: function (errormessage)
        {
            alert("Something wrong with data loading!");
            console.log(errormessage.responseText);
        }
    });
}

function getBreadcrumbs()
{
    html = "";
    event.preventDefault();
    $.ajax({
        url: "/Browser/Index?handler=Breadcrumbs",
        type: "GET",
        dataType: "json",
        success: function (result)
        {
            $.each(result, function (key, item)
            {
                if (!item.id)
                {
                    html +=
                        `<li>${item.name}<\li>`;
                    return;
                }
                else
                {
                    html +=
                        `<li>` +
                        `<a onclick='getChange("${item.id}")' href=''>${item.name}</a>` +
                        `<\li>`;
                }
            });

            console.log(html);
            $('#dd-bc-path').html(html);
        },
        error: function (errormessage)
        {
            alert("Something wrong with data loading!");
            console.log(errormessage.responseText);
        }
    });
}

function postAdd()
{
    let token = $("input[name='__RequestVerificationToken']").val();
    let files = $("#dd-input-upl").prop("files");
    let form = new FormData();
    for (var i = 0; i < files.length; i++)
    {
        form.append("files", files[i]);
    }

    if (files.length > 0)
    {
        $.ajax({
            url: "/Browser/Index?handler=Upload",
            type: 'post',
            contentType: false,
            processData: false,
            data: form,
            headers:
            {
                "RequestVerificationToken": token
            },
            success: function(response)
            {
                getContents(response);
            }
        });
    }
    else
    {
        alert('Please select files!');
    }
}

function postCopyCut(isCut)
{
    let handler = isCut ? "cut" : "copy";
    let nodes = generateSelectedJson(handler);
    let token = $("input[name='__RequestVerificationToken']").val();
    
    if (nodes.localeCompare('[]') == 0)
    {
        alert("No items are selected!");
        return false;
    }

    $.ajax({
        url: "/Browser/Index?handler=CopyCut",
        type: "POST",
        dataType: "json",
        data: { "json": nodes },
        headers:
        {
            "RequestVerificationToken": token
        },
        success: function (result)
        {
            alert(result);
            $('#brw-fo-paste').css('display', 'inline-block');

            if (isCut)
            {
                let table = document.getElementById('brw-directory');
                $('input:checkbox:checked', table).each(function ()
                {
                    $(this).attr('disabled', true);
                });
            }
        },
        error: function (errormessage)
        {
            alert("Something wrong with data loading!");
            console.log(errormessage.responseText);
        }
    });
}

function postPaste()
{
    let token = $("input[name='__RequestVerificationToken']").val();

    $.ajax({
        url: "/Browser/Index?handler=Paste",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        headers:
        {
            "RequestVerificationToken": token
        },
        success: function (result)
        {
            getContents(result);
            $('#brw-fo-paste').css('display', 'none');
        },
        error: function (errormessage)
        {
            alert("Something wrong with data loading!");
            console.log(errormessage.responseText);
        }
    });
}

function postRename()
{
    let text = $('#dd-input-txt').val();
    let token = $("input[name='__RequestVerificationToken']").val();
    let nodes = generateSelectedJson(text);

    if (text == "")
    {
        alert("Input field is empty!");
        return false;
    }
    if (nodes.localeCompare('[]') == 0)
    {
        alert("No items are selected!");
        return false;
    }

    $.ajax({
        url: "/Browser/Index?handler=Rename",
        type: "POST",
        dataType: "json",
        data: { "json": nodes },
        headers:
        {
            "RequestVerificationToken": token
        },
        success: function (result)
        {
            alert(result);
            $('#dd-input-actions').css('display', 'none');
        },
        error: function (errormessage)
        {
            alert("Something wrong with data loading!");
            console.log(errormessage.responseText);
        }
    });
}

function postDelete()
{
    let token = $("input[name='__RequestVerificationToken']").val();
    let nodes = generateSelectedJson('delete');

    if (nodes.localeCompare('[]') == 0)
    {
        alert("No items are selected!");
        return false;
    }

    let sure = confirm("Do you want to delete selected items?");
    if (sure)
    {
        $.ajax({
            url: "/Browser/Index?handler=Delete",
            type: "POST",
            dataType: "json",
            data: { "json": nodes },
            headers:
            {
                "RequestVerificationToken": token
            },
            success: function (result)
            {
                alert(result);
                getContents(result);
            },
            error: function (errormessage)
            {
                console.log(errormessage.responseText);
            }
        });
    }
}

function sortTable(n)
{
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("browser");
    switching = true;
    dir = "asc";
    while (switching)
    {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++)
        {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("td")[n];
            y = rows[i + 1].getElementsByTagName("td")[n];
            if (dir == "asc")
            {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase())
                {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc")
            {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase())
                {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch)
        {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else
        {
            if (switchcount == 0 && dir == "asc")
            {
                dir = "desc";
                switching = true;
            }
        }
    }
}

function updateSelected(count = 0)
{
	let rowTotalCount = $('#browser >tbody >tr').length - 1;
	let value = $('#browser tr:eq(2) td:eq(1)').text();
	
	if (value == "Empty Folder")
		rowTotalCount = 0;
	
	$('#selected-text').text(`Selected: ${count} of ${rowTotalCount}`);
}

var checkedCount = 0;


window.onload = function ()
{
	updateSelected();
	$('#brw-fo-paste').css('display', 'none');
	
	$('#browser >tbody input[type="checkbox"]').click(function(){

            if($(this).prop("checked") == true)
			{
				checkedCount += 1;
            }

            else if($(this).prop("checked") == false)
			{
				checkedCount -= 1;
            }
			
			updateSelected(checkedCount);

        });

    window.onclick = function (event)
    {
        if (event.target == document.getElementById("dd-input-actions"))
        {
            $("#dd-input-actions").css('display', 'none');
        }
    }
};