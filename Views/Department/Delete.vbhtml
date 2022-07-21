@ModelType WebApplication1.Department

<div class="modal-content">
    <div class="modal-header">
        <h3>Are you sure you want to delete this?</h3>
        <div>
            <h4>Department</h4>
            <hr />
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Name)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Name)
                </dd>

            </dl>
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-actions no-color">
                    <input type="submit" value="Delete" class="btn btn-default" /> |

                </div>
            End Using
        </div>
        </div>
    </div>
