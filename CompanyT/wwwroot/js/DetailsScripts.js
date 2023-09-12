

window.onload = () => {
    //var url = "Reports/DepReport?depNumber=1";
    GetCompanyData(window.location.pathname + window.location.search + '&handler=Company');
    GetNotes(window.location.pathname + window.location.search + '&handler=Notes');
}

function GetCompanyData(url) {

    const response = fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((result) => {
            $("#cid").text(result["Id"]);
            $("#cname").text(result["Name"]);
            $("#ccity").text(result["City"]);
            $("#cstate").text(result["State"]);
            $("#cadress").text(result["Adress"]);
            $("#cphone").text(result["Phone"]);
            //alert("get");
        });
}
function GetNotes(url) {

    const response = fetch(url)
        .then((response) => {
            return response.json();
        });
}
  // Default options are marked with *
 //, {
        //    method: "GET", // *GET, POST, PUT, DELETE, etc.
        //    mode: "cors", // no-cors, *cors, same-origin
        //    cache: "default", // *default, no-cache, reload, force-cache, only-if-cached
        //    credentials: "same-origin", // include, *same-origin, omit
        //    headers: {
        //        "Content-Type": "application/json",
        //        // 'Content-Type': 'application/x-www-form-urlencoded',
        //    },
        //    redirect: "follow", // manual, *follow, error
        //    referrerPolicy: "client", // no-referrer, *client
        //    body: JSON.stringify(data), // body data type must match "Content-Type" header
    //});