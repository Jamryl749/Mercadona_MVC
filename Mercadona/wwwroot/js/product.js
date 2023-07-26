var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        responsive: true,
        "ajax": { url:'/admin/product/getall' },
        "columns": [
            { data: 'name' },
            { data: 'desc' },
            { data: 'category.name', },
            {
                data: 'discount.name',
                "defaultContent": ""
            },
            {
                data: 'discount.discountValue',
                "render": function (data, type, full, meta) {
                    if (data != null) {
                        return +data + '%';
                    }
                },
                "defaultContent": ""
            },
            {
                data: 'discount.startDate',
                render: DataTable.render.date(),
                "defaultContent": ""
            },
            {
                data: 'discount.endDate',
                render: DataTable.render.date(),
                "defaultContent": ""
            },
            {
                data: 'price',
                "render": function (data, type, full, meta) {
                    return '$' +data;
                }
            },
            {
                data: 'discountedPrice',
                "render": function (data, type, full, meta) {
                    if (data != 0 && data != null) {
                        return '$' + data;
                    }
                    return null;
                },
                "defaultContent": ""
            },          
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-auto btn-group" role="group">
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-success mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/admin/product/delete?id=${data}') class="btn btn-danger mx-2">  <i class="bi bi-trash-fill"></i>Delete</a>
                        </div >`
                }
            }
        ],
    });
}

function Delete(url) {
    Notiflix.Confirm.show(
        'Are you sure?',
        "You won't be able to revert this!",
        'Yes, delete it!',
        'Nope',
        function okCb() {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success == true) {
                        dataTable.ajax.reload();
                        Notiflix.Notify.success(data.title, {
                            clickToClose: true,
                            position: 'right-bottom',
                        })
                    }
                    else {
                        dataTable.ajax.reload();
                        Notiflix.Report.failure(data.title, data.message, data.button, {
                            clickToClose: true,
                            position: 'right-bottom',
                        }
                        )
                    }
                },
            })
        },
        function cancelCB() {

        },
    );
}

