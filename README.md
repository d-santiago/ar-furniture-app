# Augmented Reality (AR) Furniture App (2022)

The following project is an augmented reality interior
design / furnishing application. The primary goal of this
application is to help users virtually decorate their homes
and in-person spaces with furniture, using their smartphones.
This application provides a visual representation of the
user’s home decor ideas to assist them in the furniture buying
process and in generating creative ideas. This application,
while intended for home furnishing, is not restricted to the
home setting. This application can also be used recreationally
by artists who have a passion for interior design; educationally
by students who want to learn the fundamentals of interior
design; and commercially by interior designers who create interior
design concepts for their clients.

## Design and Implementation

### Design

- The user can navigate the through the available furniture
  options using a scroll bar located at the bottom of
  the screen.

 - To select their desired furniture, the user must tap the
   button which that has the image (sprite) of the furniture
   of their choice.

- To spawn an object, the user must touch the horizontal
  AR plane that is detected in their camera view. The
  user can select any area on the AR plane and the object
  will spawn exactly where they touch the screen.

- The user can spawn multiple objects. When objects
  spawn, they do not overlap. They instead bump into
  each other and slightly move from the impact.

- Spawned objects retain their world space and will stay
  where they were placed regardless of whether or not
  the user moves the camera.

- The user can translate, scale, and rotate furniture. They
  can translate furniture by selecting the object and dragging
  their finger in any direction. The user can scale
  furniture by using two fingers to enlarge or shrink the
  image by increasing or decreasing distance between their
  fingertips. The user can rotate furniture by using two
  fingers and moving them in alternating circular
  motions.

- An object that is spawned, touched, or manipulated
  (translate, scale, rotate) will be selected and will
  slightly float up and down to indicate its selection.

- The user can delete objects that have been selected
  using the ”Delete Selected Furniture” button. When a
  selected object is deleted, none of the other furniture
  is selected. Another piece of furniture will need to be
  spawned, touched, or manipulated to be selected.

- The user can delete all furniture at once using the
  ”Clear All Furniture” button

### Implementation

- ARKit: Used to run the augmented reality application on iOS.

- AR Plane Manager: Detects flat surfaces in the camera’s view.
  Allows the user to place furniture on any detected flat
  horizontal surface.

- Touch: Detects when a finger is touching the screen and tracks
  its touch phase (e.g. Began, Moved, Ended).Allows users to spawn
  and reselect furniture for modification or deletion.
  
- Lean Touch: Creates customizable touch components for the furniture
  game objects which allow the user to translate, scale, and rotate them.
  
- Raycast Box Colliders: Detects when a user’s touch input collides
  with game objects. Leveraged to spawn only on the AR Plane and to
  prevent objects from spawning on top of each other.

- Rigid Bodies: Provides a physics-based way to control the movement
  of game objects. Used to make furniture bump into each other instead
  of overlapping.

- Scroll View: Contains and displays buttons. Each button corresponds
  to a different furniture prefab.

- Event Listeners: Detects when a button is clicked. This was important
  for selecting different furniture in the Scroll View and deleting spawned
  furniture.

- Sketchfab: Provided all 3D Furniture models (.fbx - Unity supported file type)
