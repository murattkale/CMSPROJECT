"use strict";
var KTLoginGeneral = function () {
    var i = $("#kt_login"),
        t = function (i, t, e) {
            var n = $('<div class="alert alert-' + t + ' alert-dismissible" role="alert">\t\t\t<div class="alert-text">' + e + '</div>\t\t\t<div class="alert-close">                <i class="flaticon2-cross kt-icon-sm" data-dismiss="alert"></i>            </div>\t\t</div>');
            i.find(".alert").remove(), n.prependTo(i), KTUtil.animateClass(n[0], "fadeIn animated"), n.find("span").html(e)
        },
        e = function () {
            i.removeClass("kt-login--forgot"), i.removeClass("kt-login--signup"), i.addClass("kt-login--signin"), KTUtil.animateClass(i.find(".kt-login__signin")[0], "flipInX animated")
        },
        n = function () {
            $("#kt_login_forgot").click(function (t) {
                t.preventDefault(), i.removeClass("kt-login--signin"), i.removeClass("kt-login--signup"), i.addClass("kt-login--forgot"), KTUtil.animateClass(i.find(".kt-login__forgot")[0], "flipInX animated")
            }), $("#kt_login_forgot_cancel").click(function (i) {
                i.preventDefault(), e()
            }), $("#kt_login_signup").click(function (t) {
                t.preventDefault(), i.removeClass("kt-login--forgot"), i.removeClass("kt-login--signin"), i.addClass("kt-login--signup"), KTUtil.animateClass(i.find(".kt-login__signup")[0], "flipInX animated")
            }), $("#kt_login_signup_cancel").click(function (i) {
                ""
                i.preventDefault(), e()
            })
        };
    return {
        init: function () {
            n(), $("#kt_login_signin_submit").click(function (i) {
                i.preventDefault();
                var e = $(this),
                    n = $(this).closest("form");
                n.validate({
                    rules: {
                        email: {
                            required: !0,
                            email: !0
                        },
                        password: {
                            required: !0
                        }
                    }
                }), n.valid() && (e.addClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").attr("disabled", !0), n.ajaxSubmit({
                    url: "/Login/Validate",
                    success: function (i, s, r, a) {
                        if (r.responseJSON != null && r.responseJSON != "" && r.responseJSON.Id > 0) {

                            if (r.responseJSON.LoginCount == null && r.responseJSON.Name != "admin") {
                                i = $("#kt_login"),
                                    i.removeClass("kt-login--signin"), i.removeClass("kt-login--signup"), i.addClass("kt-login--forgot"), KTUtil.animateClass(i.find(".kt-login__forgot")[0], "flipInX animated")
                            }
                            else {
                                location.reload();
                            }
                        }
                        else {
                            setTimeout(function () {
                                e.removeClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").attr("disabled", !1), t(n, "danger", "Kullanıcı adınız yada şifreniz hatalı. Lütfen Tekrar deneyiniz.")
                            }, 1)
                        }

                    }
                }))
            }),

                $("#kt_login_forgot_submit").click(function (n) {
                    n.preventDefault();
                    var s = $(this),
                        r = $(this).closest("form");

                    if ($('#kt_login_forgot [name="pass1"]').val() != $('#kt_login_forgot [name="passreply"]').val()) {
                        r.removeClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").attr("disabled", !1), t(r, "danger", "Şifreler birbiriyle tutuşmuyor.");
                        return;
                    }
                    r.validate({
                        rules: {
                            pass1: {
                                required: !0,
                            }
                        }
                    }), r.valid() && (s.addClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").attr("disabled", !0), r.ajaxSubmit({
                        url: "/Login/PassEdit",
                        success: function (n, a, l, o) {
                            if (l.responseJSON.LoginCount == 1) {

                                location.reload();

                            }
                        }
                    }))
                })
        }
    }
}();
jQuery(document).ready(function () {
    KTLoginGeneral.init()
});