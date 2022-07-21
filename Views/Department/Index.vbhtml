@modelType IEnumerable(Of Department)

@Code
    ViewData("Title") = "Index"
End Code

@section style
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap.min.css" />
end section
<h2>Index</h2>

<button id="btn-create" class="btn btn-success">Create Department</button>

<br />
<hr />
<br />
<table id="department-table" class="table ">
    <thead>
        <tr>
            <th>Name</th>
            <th></th>
        </tr>
    </thead>

    <tbody></tbody>

</table>


<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog" id="modalCotent">


        </div>
   </div>



        @section scripts
            <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
            <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap.min.js"></script>
            <script src="~/Scripts/dataTableScript.js"></script>
<script src="~/Scripts/jquery.unobtrusive-ajax.min.js"></script>
            <script>

                $(document).ready(function myfunction() {
                    globalTable = tablePlugin("#department-table", "/Department/GetData", [{ data: "Name" }, {
                        data: "ID", render: function (data) {
                            console.log(data);
                            return "<button class='btn btn-primary btn-edit' data-id=" + data + "> Edit </button> | <button class='btn btn-danger btn-delete' data-id=" + data + ">Delete </button>";
                        }
                    }]);

                   
                    $(document).on("click", ".btn-edit", function () {

                        $.ajax({
                            url: "/Department/Edit/"+ $(this).attr("data-id"),
                            method: "GET",
                            success: function (result) {
                                $("#modalCotent").html(result);
                                $("#myModal").modal("show")
                            }
                        })

                    });

                    

                    $(document).on("click", ".btn-delete", function () {
                       let cuurrentId = $(this).attr("data-id");
                        bootbox.confirm("Are you sure?!", function (result) {
                            if (result === true) {
                                $.ajax({
                                    url: "/Department/DeleteConfirmed",
                                    method: "POST",
                                    data: { id: cuurrentId },
                                    success: function (result) {
                                        globalTable.ajax.reload();
                                    }
                                })
                            }
                        });
                      

                    });

                });
                $("#btn-create").click(function () {

                    $.ajax({
                        url: "/Department/Create",
                        method: "GET",
                        success: function (result) {
                            $("#modalCotent").html(result);
                            $("#myModal").modal("show")
                        }
                    })

                });

               

                function requestSuccess(res) {
                    $("#myModal").modal("hide");
                    globalTable.ajax.reload();
                }


            </script>
        End Section
