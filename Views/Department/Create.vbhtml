@modelType Department

@Code
    ViewData("Title") = "Create"
End Code

@Using Ajax.BeginForm("Create", Nothing, New AjaxOptions() With {.HttpMethod = "POST", .OnSuccess = "requestSuccess"}, Nothing)
@<div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Create Department </h4>
    </div>
    <div class="modal-body">


           <div class="form-group">
                @Html.LabelFor(Function(c) c.Name)
                @Html.TextBoxFor(Function(c) c.Name,New With {.class="form-control"})

            </div>
        
           
   
    </div>
    <div class="modal-footer">
        <button type="submit" class="btn btn-default">Create</button>
    </div>
</div>
End Using