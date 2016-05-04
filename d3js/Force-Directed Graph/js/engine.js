function d3Network(jsonFile) {

var color = d3.scale.category20();
var width = 960,
    height = 500;

var force = d3.layout.force()
    .charge(-120)
    .linkDistance(30)
    .size([width, height]);

var svg = d3.select("body").append("svg")
    .attr("width", width)
    .attr("height", height);

//Create tooltip element
var tooltip = d3.select("#chart")
    .append("div")
    .attr("class", "large-3 columns")
    .attr("id", "tooltip")
    .style("position", "absolute")
    .style("z-index", "10")
    .style("opacity", 0);

function displayTooltip(node) {
    var pos = d3.mouse(this);

    tooltip.html("<span id='name'>" + node.name + "</span> : ")
        .style("top", (pos[1]) + "px")
        .style("left", (pos[0]) + "px")
        .style("z-index", 10)
        .style("opacity", .9);
}

function moveTooltip(node) {
    var pos = d3.mouse(this);
    tooltip
      .style("top", (d3.event.pageY + 10) + "px")
      .style("left", (d3.event.pageX + 10) + "px");
}

function removeTooltip(node) {
    tooltip
      .style("z-index", -1)
      .style("opacity", 0)    //Make tooltip invisible
    svg.selectAll("circle")
    .transition()
    .style("opacity", 0.8);
}

function displayPreview(e, preview) {
    var pos = [e.pageX, e.pageY + 20]
    tooltip.html(preview.innerHTML)
    .style("top", (pos[1]) + "px")
    .style("left", (pos[0]) + "px")
    .style("z-index", 10)
    .style("opacity", .9)
}

d3.json(jsonFile, function(error, graph) {
  if (error) throw error;

  force
      .nodes(graph.nodes)
      .links(graph.links)
      .start();

  var link = svg.selectAll(".link")
      .data(graph.links)
      .enter().append("line")
      .attr("class", "link")
      .style("stroke-width", function (d) {
          return Math.sqrt(d.value);
      });

  var node = svg.selectAll(".node")
      .data(graph.nodes)
      .enter().append("circle")
      .attr("class", "node")
      .attr("r", function (d) {
          return d.group;
      })
      .style("fill", function (d) {
          return color(d.group);
      })
      .style("opacity", 0.8)
        .on("mouseover", displayTooltip)
        .on("mousemove", moveTooltip)
        .on("mouseout", removeTooltip)        
      .call(force.drag);

    node.append("title")
        .style("font-size", 16)
        .html(function (d) {
            return "<i><strong>Name</strong><i>: \n" + d.name + "type: " + d.type + "Links: " + d.size;
        });

  force.on("tick", function() {
    link.attr("x1", function(d) { return d.source.x; })
        .attr("y1", function(d) { return d.source.y; })
        .attr("x2", function(d) { return d.target.x; })
        .attr("y2", function(d) { return d.target.y; });

    node.attr("cx", function(d) { return d.x; })
        .attr("cy", function(d) { return d.y; });
  });
});
	
}