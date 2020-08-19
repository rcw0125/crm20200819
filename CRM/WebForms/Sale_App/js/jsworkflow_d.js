function geturl(id, flag) {
    switch (flag) {
        case "0":
            window.location.href = "Con_CheckList.aspx?ID=" + id + "&flag=0";
            break;
        case "1":
            window.location.href = "../ZL/Quality_Check.aspx?ID=" + id + "&flag=0";
            break;
        case "2":
            window.location.href = "../Roll/roll_applyCheck.aspx?ID=" + id + "&flag=0";
            break;
    }
}

function geturl2(id, flag) {
    switch (flag) {
        case "0":
            window.location.href = "Con_CheckList.aspx?ID=" + id + "&flag=1";
            break;
        case "1":
            window.location.href = "../ZL/Quality_Check.aspx?ID=" + id + "&flag=1";
            break;
        case "2":
            window.location.href = "../Roll/roll_applyCheck.aspx?ID=" + id + "&flag=1";
            break;
    }
}