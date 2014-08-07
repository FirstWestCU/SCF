<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Coop.RegistrationPage" %>
<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->


    <!--=== Content Part ===-->
    <div class="container content">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <form id="registerForm" class="reg-page" action="registration.aspx/registerMember" method="post">
                    <div class="reg-header">
                        <h2>Register a new account</h2>
                        <p>Already Signed Up? Click <a href="login.aspx" class="color-green">Sign In</a> to login your account.</p>                    
                    </div>

                    <label>First Name</label>
                    <input name="firstName" type="text" class="form-control margin-bottom-20">
                   
                    <label>Last Name</label>
                    <input name="lastName" type="text" class="form-control margin-bottom-20">
                   
                    <label>Email Address <span class="color-red">*</span></label>
                    <input name="emailAddress" type="text" class="form-control margin-bottom-20">

                     <label>Credit Union <span class="color-red">*</span></label>
                    <select name="creditUnionId" class="form-control margin-bottom-20">
                        <%foreach (Coop.CreditUnionService.CreditUnion creditUnion in creditUnionList){ %>
                            <option value="<%=creditUnion.ID %>"><%=creditUnion.Name %></option>
                        <%
                        }
                        %>
                        </select>

                    <div class="row">
                        <div class="col-sm-6">
                            <label>Password <span class="color-red">*</span></label>
                            <input type="password" name="password" class="form-control margin-bottom-20">
                        </div>
                        <div class="col-sm-6">
                            <label>Confirm Password <span class="color-red">*</span></label>
                            <input type="password"  class="form-control margin-bottom-20">
                        </div>
                    </div>

                    <hr>

                    <div class="row">
                        <div class="col-lg-6">
                            <label class="checkbox">
                                <input type="checkbox"> 
                                I read <a href="#" class="color-green">Terms and Conditions</a>
                            </label>                        
                        </div>
                        <div class="col-lg-6 text-right">
                            <button class="btn-u" type="submit">Register</button>                        
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div><!--/container-->		
    <!--=== End Content Part ===-->
</div><!--/End Wrapepr-->

<!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->


<script type="text/javascript">
    $(document).ready(function () {
       



        //Does not need to be document on
        $(document).on('submit', '#registerForm', function () {

            $.ajax({
                type: $(this).attr('method'),
                url: $(this).attr('action'),
                data: JSON.stringify($(this).serializeObject()),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    alert(msg.d);
                    if (msg.d == "success") {
                        window.location.href=""
                    } else {

                    }
                }

            });
            return false;
        });



    //TODO - move to script utilities
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };



});
</script>