<!DOCTYPE html>
<html lang="en">

<?vb $title = "Create New Omics Project" ?>
<?vb $app = "create_project" ?>

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
        <h1>Create New Omics Project</h1>
      </div>
    </div>

    <div class="bg-white border rounded-5">

      <section class="p-4 d-flex justify-content-center w-100" style="height: 500px;">
        <ul class="stepper" data-mdb-stepper="stepper" data-mdb-stepper-type="vertical">
          <li id="expr1" class="stepper-step stepper-active">
            <div class="stepper-head">
              <span class="stepper-head-icon"> 1 </span>
              <span class="stepper-head-text"> Set Expression Matrix </span>
            </div>
            <div id="panel1" class="stepper-content py-3">
              <div class="row">
                <div class="col-8">
                  <label for="matrix-file" class="form-label">Select Matrix File:</label>
                  <div class="input-group mb-3">
                    <button class="btn btn-primary" type="button" id="button_open" data-mdb-ripple-color="dark">
                      <i class="far fa-folder-open"></i> Select File
                    </button>
                    <input type="text" class="form-control" placeholder="" id="matrix-file"
                      aria-label="Example text with button addon" aria-describedby="button-addon1" />
                  </div>
                </div>
              </div>
            </div>
          </li>
          <li id="sample2" class="stepper-step">
            <div class="stepper-head">
              <span class="stepper-head-icon"> 2 </span>
              <span class="stepper-head-text"> Set Sample Information </span>
            </div>
            <div id="panel2" class="stepper-content py-3">
              <div class="row">
                <div class="col-8">
                  <label for="matrix-file" class="form-label">Select SampleInfo File:</label>
                  <div class="input-group mb-3">
                    <button class="btn btn-primary" type="button" id="button_open" data-mdb-ripple-color="dark">
                      <i class="far fa-folder-open"></i> Select File
                    </button>
                    <input type="text" class="form-control" placeholder="" id="matrix-file"
                      aria-label="Example text with button addon" aria-describedby="button-addon1" />
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-auto">
                  <div class="p-4 text-center border-top mobile-hidden">
                    Or <a class="btn btn-link px-3 " data-ripple-color="hsl(0, 0%, 67%)" href="#"
                      onclick="apps.gcmodeller.openSampleEditor();">
                      <i class="fas fa-file-code me-md-2 pe-none"></i>
                      <span class="d-none d-md-inline-block export-to-snippet pe-none">
                        Edit in sample editor
                      </span>
                    </a> base on current expression data matrix sample id set.
                  </div>
                </div>
              </div>
            </div>
          </li>
          <li id="create3" class="stepper-step">
            <div class="stepper-head">
              <span class="stepper-head-icon"> 3 </span>
              <span class="stepper-head-text"> Create Analysis Project </span>
            </div>
            <div id="panel3" class="stepper-content py-3">

              <div class="row">
                <div class="col-4">
                  <div class="row">
                    <div class="col-12">
                      <label for="proj-title" class="form-label">Title:</label>

                      <input type="text" class="form-control" placeholder="" id="proj-title"
                        aria-label="Example text with button addon" aria-describedby="button-addon1" />

                    </div>
                  </div>
                  <div class="row">
                    <div class="col-12">
                      <label for="proj-desc" class="form-label">Description:</label>

                      <textarea class="form-control" placeholder="" id="proj-desc"
                        aria-label="Example text with button addon" aria-describedby="button-addon1"></textarea>

                    </div>
                  </div>
                </div>

                <div class="col-auto">
                  <p>Matrix summary:</p>
                  <p>Sample summary:</p>
                </div>
              </div>

              <hr />

              <div class="row">
                <div class="col-auto">


                  <button class="btn btn-primary" type="button" id="button_save" data-mdb-ripple-color="dark">
                    <i class="far fa-folder-open"></i> Create New Analysis Project
                  </button>


                </div>
              </div>

            </div>
          </li>
        </ul>
      </section>

    </div>

    <%= ../../../assets/includes/webapp.vbhtml %>

  </div>
  <!-- End your project here-->
</body>

</html>