<div id="busy-indicator" style="
z-index:999999; 
position: absolute; 
left: -25%; 
top: 0; 
float: left; 
width: 150%;
height: 100%; 
background-color: rgba(0, 0, 0, 0.555); 
display: none;">

  <div class="d-flex justify-content-center"
    style="position: absolute; left: 50%; top: 50%; transform: translate(0, -50%); color: white;">

    <div class="spinner-border" role="status">
      <span class="visually-hidden"></span>
    </div>

    <div>
      &nbsp;&nbsp;&nbsp; <span id="spinner-message">Loading...</span>
    </div>

  </div>
</div>


<div id="toast-message" class="toast-container position-fixed bottom-0 end-0 p-3" style="z-index: 11">
</div>


<section class="pb-4" id="task_submit_alert" style="display: none;">
  <div class="bg-white border rounded-5">

    <section class="text-start p-4 w-100">
      <div class="alert alert-success" role="alert" data-mdb-color="success">
        <i class="fas fa-check-circle me-3"></i>
        Background task has been submit to the automation workflow system,
        [<a href="#" onclick="apps.gcmodeller.jumptoTaskManager();">check it out at here</a>].
      </div>
    </section>

  </div>
</section>


<!-- MDB -->
<script type="text/javascript" src="/styles/bootstrap-5.0.2-dist/js/bootstrap.bundle.min.js"></script>
<script type="text/javascript" src="/styles/bootstrap5/js/mdb.min.js"></script>
<!-- Custom scripts -->
<script src="/javascript/linq.min.js" type="text/javascript"></script>
<script src="/javascript/biocad_desktop.min.js" type="text/javascript"></script>
<script src="/javascript/bs5-lightbox.bundle.min.js" type="text/javascript"></script>