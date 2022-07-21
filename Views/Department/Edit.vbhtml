@ModelType WebApplication1.Department

@Using Ajax.BeginForm("Edit", Nothing, New AjaxOptions() With {.HttpMethod = "POST", .OnSuccess = "requestSuccess"}, Nothing)
    @<div class="modal-content">
        <div class="modal-header">
            @Html.AntiForgeryToken()

            <div class="form-horizontal">
                <h4>Department</h4>
                <hr />

                @Html.HiddenFor(Function(model) model.ID)

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})

                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Save" class="btn btn-default" />
                    </div>
                </div>
            </div>
            </div>
    </div>
            End Using

