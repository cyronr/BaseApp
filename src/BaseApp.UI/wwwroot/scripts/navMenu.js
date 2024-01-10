const userDropdownId = 'user-dropdown';
const userDropdownButtonId = 'user-menu-button';

const mobileMenuId = 'navbar-user';
const mobileMenuButtonId = 'navbar-user-button';

window.addDocumentClickEvent = (dotnetHelper) => {
    document.addEventListener('click', function (event) {
        var dropdown = document.getElementById(userDropdownId);
        var button = document.getElementById(userDropdownButtonId);

        if (dropdown && button) {
            if (!dropdown.contains(event.target) && !button.contains(event.target)) {
                console.log('am here');
                dotnetHelper.invokeMethodAsync('CloseUserDropdown');
            }
        }
    });
};

function openUserDropdown() {
    var button = document.getElementById(userDropdownButtonId);
    var dropdown = document.getElementById(userDropdownId);

    if (button && dropdown) {
        var buttonRect = button.getBoundingClientRect();

        dropdown.classList.remove("hidden");

        var translateX = buttonRect.left + window.scrollX - dropdown.offsetWidth + button.offsetWidth;
        var translateY = buttonRect.bottom + window.scrollY;
        dropdown.setAttribute('style', 'position: absolute; inset: 10px auto auto 0px; margin: 0px; transform: translate(' + translateX + 'px, ' + translateY + 'px);');

        dropdown.classList.add("block");
    }
}

function closeUserDropdown(id) {
    var dropdown = document.getElementById(userDropdownId);

    if (dropdown) {
        dropdown.classList.add("hidden");
        dropdown.classList.remove("block");
    }
}

function openMobileMenu() {
    var button = document.getElementById(mobileMenuButtonId);
    var menu = document.getElementById(mobileMenuId);

    if (button && menu) {
        var buttonRect = button.getBoundingClientRect();

        menu.classList.remove("hidden");

        var translateY = buttonRect.bottom + window.scrollY;
        menu.setAttribute('style', 'position: absolute; inset: 0px auto auto 0px; margin: 0px; transform: translate(0px, ' + translateY + 'px);');

        menu.classList.add("block");
    }
}

function closeMobileMenu(id) {
    var menu = document.getElementById(mobileMenuId);

    if (menu) {
        menu.classList.add("hidden");
        menu.classList.remove("block");
    }
}


