<!DOCTYPE html>
<html lang="en">

<?vb $title = "Settings" ?>
<?vb $app = "settings" ?>

<head>
    <%= ./assets/includes/head.vbhtml %>
</head>

<body class="background">
    <!-- Start your project here-->
    <div class="container">

        <div class="form-check">
            <input class="form-check-input" type="checkbox" value="" id="RememberWindowStatus" checked />
            <label class="form-check-label" for="RememberWindowStatus">Remember Window Status</label>
        </div>

        <%= ./assets/includes/webapp.vbhtml %>
    </div>
    <!-- End your project here-->
</body>

</html>