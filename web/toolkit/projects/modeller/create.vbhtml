<!DOCTYPE html>
<html lang="en">

<?vb $title = "Create New Virtual Cell Model" ?>
<?vb $app = "create_bioproject" ?>

<head>
  <%= ../../../assets/includes/head.vbhtml %>

    <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
    <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">
    <meta name="web_invoke_loadModel" content="http://localhost:7452/database/loadModel">
</head>

<body>
  <!-- Start your project here-->
  <div class="container">

    <div class="row">
      <div class="col-auto">
        <h1>Create New Virtual Cell Model</h1>
      </div>
    </div>


    <div class="row">
      <div class="col-8">
        <label for="gbff-file" class="form-label">Imports NCBI GeneBank Model:</label>
        <div class="input-group mb-3">
          <button class="btn btn-primary" type="button" id="button_open_gbff" data-mdb-ripple-color="dark">
            <i class="far fa-folder-open"></i> Select GBFF Assembly
          </button>
          <input type="text" class="form-control" placeholder="" id="gbff-file"
            aria-label="Example text with button addon" aria-describedby="button-addon1" />
        </div>
      </div>
    </div>


    <%= ../../../assets/includes/webapp.vbhtml %>

  </div>
  <!-- End your project here-->
</body>

</html>