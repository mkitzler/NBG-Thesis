using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;

namespace NBG.Visitor.Blazor.Components
{
    public partial class CustomMudCarousel<TData> : MudCarousel<TData>, IAsyncDisposable
    {
        /// <summary>
        /// Gets or Sets if the user can navigate the carousel with swipes on a touchscreen.
        /// </summary>
        [Parameter] public bool Swipe { get; set; } = true;

        private void OnSwipe(SwipeDirection direction)
        {
            if (Swipe)
            {
                switch (direction)
                {
                    case SwipeDirection.LeftToRight:
                        Previous();
                        break;
                    case SwipeDirection.RightToLeft:
                        Next();
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or Sets if CustomNext or CustomPrevious should wrap around to the first / last item.
        /// </summary>
        [Parameter] public bool Wrap { get; set; } = true;

        /// <summary>
        /// Goes to the next item if not at the last item.
        /// </summary>
        new public void Next()
        {
            if (Wrap || SelectedIndex < Items.Count - 1)
            {
                base.Next();
            }
        }

        /// <summary>
        /// Goes to the previous item if not at the first item.
        /// </summary>
        new public void Previous()
        {
            if (Wrap || SelectedIndex > 0)
            {
                base.Previous();
            }
        }
    }
}