"use strict";
window.onload = function () {
    ; (function ($) {
        "use strict";
        if (typeof $.fn.tooltip.Constructor === 'undefined') {
            throw new Error('Bootstrap Tooltip must be included first!');
        }
        var Tooltip = $.fn.tooltip.Constructor;

        // add tooltipColor option to Bootstrap Tooltip	
        $.extend(Tooltip.Default, { tooltipColor: '' });

        var _show = Tooltip.prototype.show;
        Tooltip.prototype.show = function () {
            // invoke parent method
            _show.apply(this, Array.prototype.slice.apply(arguments));
            if (this.config.tooltipColor) {
                var tip = this.getTipElement();
                $(tip).addClass('tooltip-' + this.config.tooltipColor);
            }
        };
    })(window.jQuery);

    (function () {
        "use strict";

        // Add active state to sidbar nav links
        let path = window.location.href; // because the 'href' property of the DOM element is the absolute path
        $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
            if (this.href === path) {
                $(this).addClass("active");
            }
        });

        // Toggle the side navigation
        $("#sidebarToggle").on("click", function (e) {
            e.preventDefault();
            $("body").toggleClass("sb-sidenav-toggled");
        });



        /*	
        $('[data-toggle="tooltip"]').on('inserted.bs.tooltip', function(e) {
            const laClase = $(e.target).data('tooltip-custom-class');
            if('undefined' !== typeof laClase){
                let tooltipID = $(e.target).attr('aria-describedby');
                if('undefined' !== typeof tooltipID) $('#'+tooltipID).addClass(laClase);
            }
        });
        */

        $('[data-toggle="tooltip"]').tooltip({
            //tooltipColor:'dark',
            delay: { show: 100, hide: 50 },
            html: true,
            boundary: 'window'
        });


        //https://stackoverflow.com/a/44084113
        $.fn.existe = $.fn.existe || function () {
            return !!(this.length && (this[0] instanceof HTMLDocument || this[0] instanceof HTMLElement));
        }

        if ($(".sb-sidenav-menu").existe()) {
        //custom scroll bar is only used on desktop
        if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            $(".sb-sidenav-menu").mCustomScrollbar({
                axis: "y",
                autoHideScrollbar: true,
                scrollInertia: 300
            });
            $(".sb-sidenav-menu").addClass("desktop");
        }
        }

    })();


};




