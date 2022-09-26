// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const activePage = window.location.pathname;
if (activePage != "/")
{
    const navLinks = document.querySelectorAll('nav a').
        forEach(link => {
            if (link.href.includes(`${activePage.slice(0, 16)}`)) {
                link.classList.add(`nav-link-act`);
            }
        })
}

function Remove_hasdanger_input() 
{
    let a = document.getElementById('inputInvalid');
    let b = document.getElementById('divInvalid');
    b.classList.remove('has-danger');
    a.classList.remove(`is-invalid`);
}

//**************************Button eye show Password**************************
function show() {
    var p = document.getElementById('pwd');
    p.setAttribute('type', 'text');
}

function hide() {
    var p = document.getElementById('pwd');
    p.setAttribute('type', 'password');
}

var pwShown = 0;
function ShowPW()
{
    if (pwShown == 0) {
        console.log("0");
        pwShown = 1;
        show();
    } else {
        console.log("1");
        pwShown = 0;
        hide();
    }
}
//**************************Label notif error**************************
function Removelabel()
{
    document.getElementById('span_text_danger').innerHTML="";
}
