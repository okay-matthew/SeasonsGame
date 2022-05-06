## Seasons Level Creation Guide

# Creating a level
Create a new scene. Then take the 'level template' prefab and drag it into the scene. This will give you the basic elements of a level

# Tile Palette
There are multiple different tile palettes to build the level. 

Each tile palette has a corresponding layer. If you wish to edit the terrian layer, for example, go to the terrian palette and ensure you are painting on the terrian layer. 

Some tiles are only available in certain seasons. This can be confusing, but this is because of the special properties of some tiles. To ensure that you have full access to the tile palette, have the inspector open on the Season singleton. Draw out how you desire the level to look like *in that season.* After you have completeled the season, change the singleton to a different season and wait for the tilemap to refresh (or enter playmode if it takes too long). Then, with all the tiles having changed their states, you will have a view of what the level looks like during the new season. Paint on any tiles you desire. Repeat for each season.

NOTE: The developer has flexibility to add objects that appear and disappear with the seasons. Or the objects could just change properties. Follow the same directions as above, but drag and drop objects into the scene. 

# Example: Creating Water. 
When you create water that you wish to freeze over during the winter, go into the water layer and draw out water tiles as you desire. Then, take the ice tile and paint the ice tiles on the top of the water where you desire it to freeze. This allows developer flexibiltiy. You can have singular chunks of ice that melt and do not reveal water during other seasons. 