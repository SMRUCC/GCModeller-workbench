<!doctype html>
<html lang="en">


<?vb $title = "NCBI Taxonomy Database Toolkit" ?>
<?vb $app = "enrichment_database" ?>

<head>
  <%= ../assets/includes/head.vbhtml %>
</head>

<body>

  <div class="container-fluid">
    <div class="row">
      <div class="col">
        <div class="mb-3">
          <label for="formFile" class="form-label">Imports UniProt database assembly as background model:</label>
          <input class="form-control" type="file" id="formFile" accept="application/xml">
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-auto">
        <button type="submit" class="btn btn-primary mb-3">Imports</button>
      </div>
    </div>


    <%= ../assets/includes/webapp.vbhtml %>

  </div>


</body>

</html>