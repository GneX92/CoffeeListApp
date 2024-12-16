function showConfirmDialog(keystr) {
    const userConfirmed = confirm(`Are you sure you want to delete "${keystr}"?`);
    if (userConfirmed) {
        // User clicked OK, make AJAX request
        callActionMethod(keystr);
    } else {
        // Cancelled
    }
}

function callActionMethod(name) {
    $.ajax({
        type: "GET",
        url: "/Home/DeleteEntry",
        data: { name: name },
    }).done(function (result) {
        $('#main_div').html(result);;
    });
}

function showNamePrompt(keystr) {
    let newName = prompt(``,`${keystr}`);
    if (newName == null || newName == "") {  
        //Cancelled
    } else {
        callActionUpdate(keystr, newName); 
    }
}

function callActionUpdate(name, newname) {
    $.ajax({
        type: "GET",
        url: "/Home/UpdateEntry",
        data: { name: name, newname: newname },
    }).done(function (result) {
        $('#main_div').html(result);;
    });
}

function callActionUpdateCount(name, newcount) {
    $.ajax({
        type: "GET",
        url: "/Home/UpdateCount",
        data: { name: name, newcount: newcount },
    }).done(function (result) {
        $('#main_div').html(result);;
    });
}