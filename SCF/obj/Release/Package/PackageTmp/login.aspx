<%@ Page Language="C#" %>
<!-- #include file="includes/htmlOpen.html" -->


<!--=== Content Part ===-->    
<div class="container">
    <!--Reg Block-->
    <div class="reg-block">
        <div class="reg-block-header">
            <h2>Sign In</h2>
            <!--ul class="social-icons text-center">
                <li><a class="rounded-x social_facebook" data-original-title="Facebook" href="#"></a></li>
                <li><a class="rounded-x social_twitter" data-original-title="Twitter" href="#"></a></li>
                <li><a class="rounded-x social_googleplus" data-original-title="Google Plus" href="#"></a></li>
                <li><a class="rounded-x social_linkedin" data-original-title="Linkedin" href="#"></a></li>
            </ul-->
            <p>Don't Have Account? Click <a class="color-green" href="registration.aspx">Sign Up</a> to registration.</p>            
        </div>

        <div class="input-group margin-bottom-20">
            <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
            <input type="text" class="form-control" placeholder="Email">
        </div>
        <div class="input-group margin-bottom-20">
            <span class="input-group-addon"><i class="fa fa-lock"></i></span>
            <input type="text" class="form-control" placeholder="Password">
        </div>
        <hr>
        <label class="checkbox">
            <input type="checkbox"> 
            <p>Always stay signed in</p>
        </label>
                                
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <button type="submit" class="btn-u btn-block">Log In</button>
            </div>
        </div>
    </div>
    <!--End Reg Block-->
</div><!--/container-->
<!--=== End Content Part ===-->


<!-- #include file="includes/htmlClose.html" -->
