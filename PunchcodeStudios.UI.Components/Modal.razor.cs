using Microsoft.AspNetCore.Components;

namespace PunchcodeStudios.UI.Components
{
    public partial class Modal
    {

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string CancelText { get; set; } = "Cancel";

        [Parameter]
        public string ConfirmText { get; set; } = "Ok";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Show { get; set; }


        [Parameter] public EventCallback OnCancel { get; set; }
        [Parameter] public EventCallback OnConfirm { get; set; }

    }
}