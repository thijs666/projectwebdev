// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function (event) {

    // Highlight active menu item
    document.querySelectorAll('.nav_item a').forEach(link => {
        if (link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) {
            link.classList.add('active');
        } else {
            link.classList.remove('active');
        }
    });


    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        // Elements we will be working with
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)

        // Set up an empty global var to store the state later
        var sidebarCollapsed;

        // Default State
        var collapseSidebarOnLoad = true;

        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // Alternate sidebarCollapsed between collapsed and not collapsed
                sidebarCollapsed = !sidebarCollapsed

                // Check if the content has collapse-on-load class
                if (nav.classList.contains('collapse-on-load')) {
                    // if it does, remove the class so we can add the "show" class later
                    nav.classList.remove('collapse-on-load');
                }

                // Check if the sidebar should collapse
                if (sidebarCollapsed) {
                    // Add classes to the content
                    nav.classList.add('show');
                    toggle.classList.add('bi-x-lg')
                    bodypd.classList.add('body-pd')
                    headerpd.classList.add('body-pd')

                    // Add collapsed state to localStorage
                    localStorage.setItem('sidebar', 'collapsed');
                } else {
                    // If sidebar shouldn't open, remove the classes
                    nav.classList.remove('show');
                    toggle.classList.remove('bi-x-lg')
                    bodypd.classList.remove('body-pd')
                    headerpd.classList.remove('body-pd')

                    // Remove collapsed state from localStorage
                    localStorage.setItem('sidebar', 'closed');
                }      
            })
        }

        // Check if the storage item exists at all
        if (localStorage.getItem('sidebar') === null) {
            // If it doesnt, user has not visited the site
            // Set state to default state
            sidebarCollapsed = collapseSidebarOnLoad;
        } else {
            // If the storage item exists and the value is collapsed
            if (localStorage.getItem('sidebar') === 'collapsed') {
                // Set state to collapsed
                sidebarCollapsed = true;
            } else {
                // Value should be false
                sidebarCollapsed = false;
            }
        }

        // Does the collapsed item exist or is the default state true?
        if (sidebarCollapsed) {
            // If so, the sidebar should open on page load
            // Add collapse on load class
            nav.classList.add('collapse-on-load');
        }

        // If sidebar needs to collapse on load, add classes
        if (nav.classList.contains('collapse-on-load')) {
            nav.classList.add('show');
            toggle.classList.add('bi-x-lg')
            bodypd.classList.add('body-pd')
            headerpd.classList.add('body-pd')
        }
    }

    showNavbar('sidebar_toggle', 'nav_bar', 'body_pd', 'header')
});