<!DOCTYPE html>
<html lang="en">

<?vb $title = "Install Uniprot Database Repository" ?>
<?vb $app = "uniprot_database" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/ec_numbers?rweb_background=true">

</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>Install Uniprot Database</h1>

        <div class="row">
            <div class="col">
                <label for="matrix-file" class="form-label">Select UniProt Assembly:</label>
                <div class="input-group mb-3">
                    <button class="btn btn-primary" type="button" id="button_open_uniprot" data-mdb-ripple-color="dark">
                        <i class="far fa-folder-open"></i> Open UniProt
                    </button>
                    <input type="text" class="form-control" placeholder="" id="uniprot-file"
                        aria-label="Example text with button addon" aria-describedby="button-addon1" />
                </div>

                <button class="btn btn-primary" type="button" id="run" data-mdb-ripple-color="dark">
                    <i class="far fa-folder-open"></i> Build Database
                </button>
            </div>
        </div>

        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>