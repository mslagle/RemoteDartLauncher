$width = 120;
$length = 80;
$wall = 3;
$height = 40;

$pegDiameter = 6;

$boardWidth = 34;
$boardLength = 54;

$pvc_od = 23;
$openingLength = 10;
$lip = 20;

all();

module all()
{
    difference()
    {
        union()
        {
            cube([$length, $width, $wall]);
            cube([$wall, $width, $height]);

            pegs();
            servo();

            //color("red")
            //opening();
        }
        
        openinghole();
    }
}

module pegs()
{
    translate([10, $width-$pegDiameter/2, 0])
        cylinder($height/2, d = $pegDiameter);
    
    translate([10+$boardLength, $width-$pegDiameter/2, 0])
        cylinder($height/2, d = $pegDiameter);
    
    translate([10+$boardLength, $width-$pegDiameter/2 - $boardWidth, 0])
        cylinder($height/2, d = $pegDiameter);
    
    translate([10, $width-$pegDiameter/2 - $boardWidth, 0])
        cylinder($height/2, d = $pegDiameter);
}

module servo()
{
    translate([0, $width/2 - 15, 0])
    cube([20, 5, $height]);
    
    translate([20 + 40, $width/2 - 15, 0])
    cube([20, 5, $height]);
    
    translate([20 + 40 + 20 - 5, $width/2 - 15 - 20, 0])
    cube([5, 20, $height]);
}

module opening()
{    
    translate([-$openingLength, $width/2, $height/2])
    rotate([0,90, 0])
    {
        cylinder($openingLength, d = $pvc_od + 5);
        
        translate([-5, -($pvc_od + $lip)/2, 0])
        cube([10, $pvc_od + $lip, 9]);
    }
    
    
}

module openinghole()
{
    translate([-$openingLength, $width/2, $height/2])
    rotate([0,90, 0])
    {
        cylinder($openingLength + $wall + 2, d = $pvc_od);
        
        translate([-3/2, -($pvc_od + $lip)/2, 0])
        cube([3, $pvc_od + $lip, 10]);
    }
}
