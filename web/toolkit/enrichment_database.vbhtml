<!DOCTYPE html>
<html lang="en">

<?vb $title = "Enrichment Database Repository" ?>
<?vb $app = "enrichment_database" ?>

<head>
  <%= ../assets/includes/head.vbhtml %>

    <link rel="stylesheet" href="/javascript/Clusterize/clusterize.css" />

    <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
    <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">
    <meta name="web_invoke_loadModel" content="http://localhost:7452/database/loadModel">
</head>

<body>
  <!-- Start your project here-->
  <div class="container">

    <!-- Tabs navs -->
    <ul class="nav nav-tabs mb-3" id="ex-with-icons" role="tablist">
      <li class="nav-item" role="presentation">
        <a class="nav-link active" id="ex-with-icons-tab-1" data-mdb-toggle="tab" href="#ex-with-icons-tabs-1"
          role="tab" aria-controls="ex-with-icons-tabs-1" aria-selected="true"><i
            class="fas fa-chart-pie fa-fw me-2"></i>Enrichment Database Repository</a>
      </li>
      <li class="nav-item" role="presentation">
        <a class="nav-link" id="ex-with-icons-tab-2" data-mdb-toggle="tab" href="#ex-with-icons-tabs-2" role="tab"
          aria-controls="ex-with-icons-tabs-2" aria-selected="false"><i class="fas fa-cogs fa-fw me-2"></i>Imports
          Uniprot Database</a>
      </li>
    </ul>
    <!-- Tabs navs -->

    <!-- Tabs content -->
    <div class="tab-content" id="ex-with-icons-content">
      <div class="tab-pane fade show active" id="ex-with-icons-tabs-1" role="tabpanel"
        aria-labelledby="ex-with-icons-tab-1">

        <div class="row">
          <div class="col-md-6" id="repository">
            <!-- show repository card list -->

          </div>
          <div class="col-md-6">
            <!-- show database metadata -->
            <p>Database Summary:</p>

            <div class="row">

              <div id="summary-info" class="shadow-3 col"
                style="background-color: white; padding-top: 10px; padding-bottom: 10px;">

              </div>
            </div>
          </div>
        </div>

      </div>
      <div class="tab-pane fade" id="ex-with-icons-tabs-2" role="tabpanel" aria-labelledby="ex-with-icons-tab-2">

        <div class="d-flex justify-content-center align-items-center" style="height: 100vh">
          <div class="row">
            <div class="col">
              <div class="card">
                <div class="card-body">
                  <h5 class="card-title">Select Database File</h5>
                  <p class="card-text">

                    Imports UniProt database assembly as background model:
                    <br />
                    <label for="formFile" class="form-label">Local File</label>
                    <input class="form-control" type="text" id="formFile" required>
                  </p>
                  <button id="open_uniprot" type="button" class="btn btn-primary mb-3">Open</button>
                </div>
              </div>
            </div>

            <div class="col-auto">

              <div class="card">
                <div class="card-body">
                  <h5 class="card-title">Task Configuration</h5>
                  <p class="card-text">
                    <label for="title" class="form-label">Database Name:</label>
                    <input class="form-control" type="text" id="title">
                    <label for="description" class="form-label">Notes:</label>
                    <textarea class="form-control" id="description" rows="5"></textarea>
                  </p>
                  <button id="imports" type="submit" class="btn btn-primary mb-3">Imports</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

    </div>
    <!-- Tabs content -->

    <!-- Modal -->
    <div class="modal fade" id="view-background" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">View Background Cluster</h5>
            <button id="modal-close1" type="button" class="btn-close" data-mdb-dismiss="modal"
              aria-label="Close"></button>
          </div>
          <div id="background-content" class="modal-body">


            <div id="scrollArea" class="clusterize-scroll">
              <ol id="contentArea" class="clusterize-content">

              </ol>
            </div>

            <div class="row">
              <div class="col">
                <label for="protein_ids" class="form-label"></label>
                <textarea class="form-control" rows="6" id="protein_ids" readonly>
                </textarea>
              </div>
            </div>

          </div>
          <div class="modal-footer">
            <button id="modal-close2" type="button" class="btn btn-secondary" data-mdb-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>


    <%= ../assets/includes/webapp.vbhtml %>

      <script type="text/javascript" src="/javascript/Clusterize/clusterize.min.js"></script>

  </div>
  <!-- End your project here-->
</body>

</html>