$(function () {
    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick)

    function onUserLoginClick() {
        var url = "UserAuth/Login";

        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name= 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');
      //  alert("email is " + email, " password is " + password + "remember me " + rememberMe);

        //alert(antiForgeryToken);
        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };

        //  console.log(userInput);
        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                if (hasErrors == true) {

                    $("#UserLoginModal").html(data);
                    userLoginButton = $("UserLoginModal button[name='login']").click(onUserLoginClick)
                }
                else {

                    //console.log("login successfully")
                    location.href = 'Home/Index';
                    

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);

            }
        });
    }
}); 