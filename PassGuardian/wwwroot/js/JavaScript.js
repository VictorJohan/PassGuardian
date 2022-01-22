function show(id, idbtn) {
    var x = document.getElementById(id);
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }

    changeColorButton(idbtn);
}

function changeColorButton(id) {
    
    var x = document.getElementById(id);
    if (x.classList.contains("btn-danger")) {
        x.classList.remove("btn-danger");
        x.classList.add("btn-success")
    } else {
        x.classList.remove("btn-success");
        x.classList.add("btn-danger")
    }
}

function copyToClipBoard(id) {

    var content = document.getElementById(id);
    content.type = "text";
    content.select();
    document.execCommand('copy');
    content.type = "password";
}

function w3_open() {
    //document.getElementById("main").style.marginLeft = "30%";
    //document.getElementById("mySidebar").style.width = "30%";
    document.getElementById("mySidebar").style.display = "table";
    document.getElementById("openNav").style.display = 'none';
}
function w3_close(id, title) {
    document.getElementById("main").style.marginLeft = "0%";
    document.getElementById("mySidebar").style.display = "none";
    document.getElementById("openNav").style.display = "inline-block";
    chancgeTitlt(id, title)
}

function chancgeTitlt(id, title) {
    document.getElementById(id).innerHTML = title;
}


function myFunction() {
    alert(Hola);
}