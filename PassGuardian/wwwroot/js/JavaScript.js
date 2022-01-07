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