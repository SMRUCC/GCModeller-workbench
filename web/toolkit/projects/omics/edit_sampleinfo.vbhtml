<!DOCTYPE html>
<html lang="en">

<?vb $title = "Edit Sample Information" ?>
<?vb $app = "edit_sampleinfo" ?>

<head>
    <%= ../../../assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
        <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">
        <meta name="web_invoke_loadModel" content="http://localhost:7452/database/loadModel">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>Edit Sample Information</h1>


        <div class="row">
            <div class="edit_sampleinfo col-12">

                <p style="margin: -20px 0 20px 0;">{$sampleinfo} <i title="{$tooltip}" class="fa fa-question-circle-o"
                        id="open_illustrate_sample" style="width: 20px;font-size: 20px;"></i></p>

                <div id="edit_sampleinfo">

                </div>
            </div>
        </div>



        <%= ../../../assets/includes/webapp.vbhtml %>

            <script type="text/javascript" src="/javascript/sampleinfo_editor.min.js"></script>

    </div>
    <!-- End your project here-->
</body>

</html>