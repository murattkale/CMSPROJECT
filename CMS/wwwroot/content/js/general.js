if (window.addEventListener) {
    window.addEventListener('load', general_Load, false);
}
else {
    window.attachEvent('onload', general_Load);
}

function general_Load() {
    window.onbeforeunload = setClick;
}
var postArray = [];
function setClick() {
    for (var i = 0; i < postArray.length; i++) {
        postArray[i].abort();
    }
    // cl();
}



var ContentPageTypeEnum = {
    Sayfa: 2,
    row1: 3,
    row2: 4,
    row3: 5,
    row4: 6,
    sliderUst: 7,
    sliderAlt: 8,
    etkinlikler: 9,
    haberler: 10,
    haberler3: 11,
    etkinlikler3: 12,
    galeri: 13,
};


var toStr = function (e) {
    return e == undefined || e == "undefined" || e == null || e == "null" ? "" : e.toString();
};

var toInt = function (e) {
    return e == undefined || e == "undefined" || e == null || e == "null" ? null : parseInt(e);
};



var toDouble = function (e) {
    return e == undefined || e == "undefined" || e == null || e == "null" ? null : parseFloat(e);
};

var isBool = function (variable) {
    if (typeof (variable) === "boolean") {
        return true;
    }
    else {
        return false;
    }
}

var toBool = function (value) {
    return value == true ? "True" : "False";
}

var isNumeric = function (n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

jQuery('.isnumeric').keyup(function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});


function getObjects(obj, key, val) {
    var objects = [];
    for (var i in obj) {
        if (!obj.hasOwnProperty(i)) continue;
        if (typeof obj[i] == 'object') {
            objects = objects.concat(getObjects(obj[i], key, val));
        } else
            if (i == key && obj[i] == val || i == key && val == '') { //
                objects.push(obj);
            } else if (obj[i] == val && key == '') {
                if (objects.lastIndexOf(obj) == -1) {
                    objects.push(obj);
                }
            }
    }
    return objects;
}





function getEnumList(dataResult, id, selectid, selectText) {
    $(id).addOption(dataResult, "value", "text", null, null, selectid, '', selectText);
}

function getEnumRow(dataResult, value) {
    if (value < 1) {
        row = { value: "", text: "" };
        return row;
    }


    var row;
    for (var i = 0; i < dataResult.length; i++) {
        var rowItem = dataResult[i];
        if (parseInt(rowItem.value) == parseInt(value)) {
            row = rowItem;
            break;
        }
    }
    return row;
}




(function ($) {
    "use strict";



    var postArray = [];
    $.ajx = function (url, data, successMethod, error) {
        //if (typeof data != "string" && data != null) {
        //    data = JSON.stringify(data);
        //}

        var slash = url.substr(0, 1) == "/" ? "" : "/";

        var post = $.post(slash + baseUrl + url, data, successMethod)
            .fail(function (e, exception) {
                if (error) {
                    error = $.fn.errorSend(e, exception);
                    console.log(error);
                }
            });
        postArray.push(post);
    };

    $.fn.errorSend = function (e, exception) {
        var error = '';
        if (e.status === 0) {
            error = 'Not connect. Verify Network.';
        } else if (e.status === 404) {
            error = 'Requested page not found. [404]';
        } else if (e.status === 500) {
            error = 'Internal Server Error [500].';
        } else if (exception === 'parsererror') {
            error = 'Requested JSON parse failed.';
        } else if (exception === 'timeout') {
            error = 'Time out error.';
        } else if (exception === 'abort') {
            error = 'Ajax request aborted.';
        } else {
            error = 'Uncaught Error. \n' + error.responseText;
        }
        var data = { error: error };

        return error;
    };

    $.fn.addOption = function (selectValues, value, text, dpChange, dpSuccess, selectValue, selectText, selectDefault, attrName, attrValue) {
        var id = this;
        $(id).html('');

        if (selectDefault) {
            var optionsAll = $("<option></option>")
                .attr("value", '')
                .text(selectDefault);
            $(id).append(optionsAll);
        }

        $.each(selectValues, function (i, item) {
            var optionsAll = $("<option></option>")
                .attr("value", item[value])
                .text(item[text]);

            if (attrName)
                $(optionsAll).attr(attrName, attrValue);

            if (selectValue != null && value != '' && value != undefined && selectValue.toString() == item[value].toString()) {
                $(optionsAll).attr('selected', "selected");
            }
            if (selectText != null && text != '' && text != undefined && selectText == item[text]) {
                $(optionsAll).attr('selected', "selected");
            }

            $(id).append(optionsAll);
        });

        if (dpChange)
            $(document).on('change', '#' + $(id)[0].id, function () { dpChange(); });

        if (dpSuccess)
            dpSuccess();

        $(id).select2({});
    };

    $.fn.addOptionAjax = function (url, param, value, text, dpChange, dpSuccess, selectValue, selectText, selectDefault, attrName, attrValue) {
        var id = this;
        $(id).LoadingOverlay("show");
        $(id).html('');
        $.ajx(url, param, function (dataResult) {
            $(id).addOption(dataResult, value, text, dpChange, dpSuccess, selectValue, selectText, selectDefault, attrName, attrValue);
            $(id).LoadingOverlay("hide");
        }, null);

    };


    $.fn.toForm = function (id) {//serialize data function
        var formArray = $(id).serializeArray();
        var returnArray = {};

        for (var i = 0; i < formArray.length; i++) {
            var finame = (formArray[i]['name']).toString();
            var fivalue = (formArray[i]['value']).toString();
            if (finame.indexOf("Id") != -1 && fivalue == "-1") {
                returnArray[formArray[i]['name']] = null;
            }
            else {
                returnArray[formArray[i]['name']] = fivalue.trim();
            }
        }
        $(id + ' select[disabled],' + id + ' select').each(function () {

            var dp = $(this).attr('name');
            if (dp.indexOf('dp_') != -1) {
                dp = dp.substr(3, dp.length - 1);
            }

            returnArray[dp] = $(this).val();


            if (dp.indexOf('Id') != -1 && ($(this).val() == "-1" || $(this).val() == "0" || $(this).val() == "")) {
                returnArray[dp] = null;
            }

            delete returnArray[$(this).attr('name')];

        });
        $(id + ' input[disabled]').each(function () {
            returnArray[$(this).attr('name')] = $(this).val().trim();
        });


        $(id + ' textarea').each(function () {

            returnArray[$(this).attr('name')] = CKEDITOR.instances[$(this).attr('name')].getData();
        });

        $(id + ' input[type="checkbox"]').each(function () {
            returnArray[$(this).attr('name')] = $(this).prop("checked");
        });

        return returnArray;
    };


    $.ajxUpload = function (url, data, successMethod, error) {
        //if (typeof data != "string" && data != null) {
        //    data = JSON.stringify(data);
        //}

        var slash = url.substr(0, 1) == "/" ? "" : "/";

        $.ajax({
            url: slash + baseUrl + url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: data,
            success: successMethod,
            error: function (error) {
                if (error) {
                    error = $.fn.errorSend(e, exception);
                    console.log(error);
                }
            }
        });

    };




})(jQuery);


function getFT(id) {

    var dataResult = getFormTypeList();
    var row;
    for (var i = 0; i < dataResult.length; i++) {
        var rowItem = dataResult[i];
        if (rowItem.Id == id) {
            row = rowItem;
            break;
        }
    }

    return row;
}

function getFormTypeList() {
    var dataResult = [];
    dataResult.push({ Id: 1, Name: "Anasayfa" });
    dataResult.push({ Id: 2, Name: "Şube" });
    dataResult.push({ Id: 3, Name: "Franch" });
    dataResult.push({ Id: 9, Name: "ilkteknem.com" });

    return dataResult;
}


(function ($) {
    $.fn.ceo = function (ayarlar) {
        var ayar = $.extend({
            'source': '#' + $(this)[0].id,
            'target': "",
        }, ayarlar);

        $(ayar.source).on("keyup", function () {
            str = $(this).val();
            str = replaceSpecialChars(str);
            str = str.toLowerCase();
            str = str.replace(/\s\s+/g, ' ').replace(/[^a-z0-9\s]/gi, '').replace(/[^\w]/ig, "-");
            function replaceSpecialChars(str) {
                var specialChars = [["ş", "s"], ["ğ", "g"], ["ü", "u"], ["ı", "i"], ["_", "-"],
                ["ö", "o"], ["Ş", "S"], ["Ğ", "G"], ["Ç", "C"], ["ç", "c"],
                ["Ü", "U"], ["İ", "I"], ["Ö", "O"], ["ş", "s"]];
                for (var i = 0; i < specialChars.length; i++) {
                    str = str.replace(eval("/" + specialChars[i][0] + "/ig"), specialChars[i][1]);
                }
                return str;
            }
            $(ayar.target).val(str);
        });
    };

})(jQuery);

(function ($) {
    $.fn.dup = function (ayarlar) {
        var ayar = $.extend({
            'source': '#' + $(this)[0].id,
            'target': "",
        }, ayarlar);

        $(ayar.source).on("keyup", function () {
            str = $(this).val();
            $(ayar.target).val(str);
        });
    };

})(jQuery);


function alerts(message, button, call) {
    var but = [];
    if (button == "yesno") {
        but = {
            confirm: {
                label: "Yes",
                className: 'btn-success'
            },
            cancel: {
                label: "No",
                className: 'btn-danger'
            }
        };
    }
    else if (button == "ok") {
        but = {
            confirm: {
                label: "OK",
                className: 'btn-success'
            }
        };
    }

    if (call) {
        bootbox.confirm({
            message: message,
            buttons: but,
            callback: call,
        });
    }
    else {
        bootbox.alert(message);
    }

}



function fileUpload(id) {


    $(id).change(function () {
        try {
            $.LoadingOverlay("show");

            if (window.FormData !== undefined) {
                var fileUpload = $('#' + this.id).get(0);
                var files = fileUpload.files;
                var fileData = new FormData();


                for (var i = 0; i < files.length; i++) {
                    fileData.append('files', files[i]);
                }

                $.ajax({
                    url: '/uploader',
                    type: "POST",
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (result) {
                        $.LoadingOverlay("hide");
                        if ($(fileUpload).attr('for'))
                            $('#' + $(fileUpload).attr('for')).val(result[0]);
                    },
                    error: function (err) {
                        $.LoadingOverlay("hide");
                        console.log(err.statusText);
                    }
                });
            } else {
                $.LoadingOverlay("hide");
                alert("Lütfen dosya seçiniz");
            }

        } catch (e) {
            console.log(e);
            $.LoadingOverlay("hide");
        }

    });

}


