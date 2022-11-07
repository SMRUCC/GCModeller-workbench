<!doctype html>
<html lang="en">

<?vb $title = "Localblast Viewer" ?>
<?vb $app = "blastp_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>
</head>

<body>

    <div class="container-fluid container">

        <h1>View Localblast result</h1>

        <div class="row">
            <div class="col-auto">
                get <span id="number_proteins"></span> Proteins
            </div>
        </div>

        <div class="row">
            <div class="col-auto" id="blast_output">
            </div>
        </div>

        <div class="row">
            <div class="col-auto">

                <div id="preview_1">

                </div>

            </div>
        </div>


        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>

    </div>

</body>

</html>