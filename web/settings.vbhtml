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

        <h1>Settings</h1>

        <div class="row">
            <div class="col-auto">

                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="RememberWindowStatus" checked />
                    <label class="form-check-label" for="RememberWindowStatus">Remember Window Status</label>
                </div>

            </div>
        </div>

        <div class="row">
            <div class="col-auto">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="CloseAfterProjectLoad" checked />
                    <label class="form-check-label" for="CloseAfterProjectLoad">Close After Project Load</label>
                </div>

                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="ShowOnStartUp" checked />
                    <label class="form-check-label" for="ShowOnStartUp">Show On StartUp</label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-auto">

                <p>Window Language:</p>

                <select id="language" class="form-select select-input placeholder-active">
                    <option value="System" selected>Follow System</option>
                    <optgroup label="Variant Languages">
                        <option value="zh-CN">简体中文</option>
                        <option value="en-US">English</option>
                        <option value="fr-FR">Français</option>
                    </optgroup>
                </select>

            </div>
        </div>

        <%= ./assets/includes/webapp.vbhtml %>
    </div>
    <!-- End your project here-->
</body>

</html>