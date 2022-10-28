<!DOCTYPE html>
<html lang="en">

<?vb $title = "Virtual Cell Project" ?>
<?vb $app = "bioproject" ?>

<head>
    <%= ../../../assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/modeller/create_project">
        <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_genbank">

</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <div class="row">
            <div class="col-auto">
                <h1>Virtual Cell Model</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-auto">
                <h2>Project Task</h2>
            </div>
        </div>


        <%= ../../../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>