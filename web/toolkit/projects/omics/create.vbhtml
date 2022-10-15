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

    <h1>Create New Omics Project</h1>


    <!--Section: vertical stepper example-->
    <section id="section-vertical-stepper-example">
      <!-- Section title -->
      <h2 class="mb-4">Introduction</h2>
      <p>
        A omics data analysis project consist with two essential data object:

      <ol>
        <li>Expression data matrix:</li>
        <li>Sample information:</li>
      </ol>

      </p>
      <!--Section: Demo-->
      <section class="pb-4">
        <div class="bg-white border rounded-5">

          <section class="p-4 d-flex justify-content-center w-100" style="height: 600px;">
            <ul class="stepper" data-mdb-stepper="stepper" data-mdb-stepper-type="vertical">
              <li id="expr1" class="stepper-step stepper-active">
                <div class="stepper-head">
                  <span class="stepper-head-icon"> 1 </span>
                  <span class="stepper-head-text"> Set Expression Matrix </span>
                </div>
                <div class="stepper-content py-3">
                  <div class="row">
                    <div class="col-auto">
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
                <div class="stepper-content py-3">
                  <span>
                    Lorem ipsum dolor sit amet enim. Etiam ullamcorper. Suspendisse a pellentesque dui,
                    non felis. Maecenas malesuada elit lectus felis, malesuada ultricies.
                  </span>
                </div>
              </li>
              <li id="create3" class="stepper-step">
                <div class="stepper-head">
                  <span class="stepper-head-icon"> 3 </span>
                  <span class="stepper-head-text"> Create Analysis Project </span>
                </div>
                <div class="stepper-content py-3">
                  <span>
                    Lorem ipsum dolor sit amet enim. Etiam ullamcorper. Suspendisse a pellentesque dui,
                    non felis. Maecenas malesuada elit lectus felis, malesuada ultricies.
                  </span>
                </div>
              </li>
            </ul>
          </section>



          <div class="p-4 text-center border-top mobile-hidden">
            <a class="btn btn-link px-3" data-mdb-toggle="collapse" href="#example6" role="button" aria-expanded="false"
              aria-controls="example6" data-ripple-color="hsl(0, 0%, 67%)">
              <i class="fas fa-code me-md-2"></i>
              <span class="d-none d-md-inline-block">
                Show code
              </span>
            </a>


            <a class="btn btn-link px-3 " data-ripple-color="hsl(0, 0%, 67%)">
              <i class="fas fa-file-code me-md-2 pe-none"></i>
              <span class="d-none d-md-inline-block export-to-snippet pe-none">
                Edit in sandbox
              </span>
            </a>

          </div>


        </div>
      </section>


      <%= ../../../assets/includes/webapp.vbhtml %>

  </div>
  <!-- End your project here-->
</body>

</html>