@{

    @using SnQTask.AspMvc.Modules.Handler
    @using SnQTask.AspMvc.Modules.View
    @model IEnumerable<SnQTask.AspMvc.Models.IdentityModel>;

    var viewBagWrapper = new ViewBagWrapper(ViewBag);
    viewBagWrapper.Controller = ViewContext.RouteData.Values["controller"].ToString();
    viewBagWrapper.Action = ViewContext.RouteData.Values["action"].ToString();

    ViewData["Title"] = viewBagWrapper.Title;
    <h1>@viewBagWrapper.Title</h1>

    if(string.IsNullOrEmpty(ErrorHandler.LastViewError) == false)
    {
        @ErrorHandler.GetLastViewErrorAndClear()
        ;
    }
    else
    {
        if((viewBagWrapper.CommandMode & SnQTask.AspMvc.Models.Modules.Common.CommandMode.Edit)>0)
        {
            <p>
                <a asp-action="Create" class="btn btn-outline-secondary">@viewBagWrapper.TranslateFor("Create New")</a>
            </p>
        }
        @await Html.PartialAsync("_IndexList",Model)
    }


}
