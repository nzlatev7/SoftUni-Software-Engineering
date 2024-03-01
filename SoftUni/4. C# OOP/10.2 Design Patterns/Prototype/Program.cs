
using Prototype;

SandwichMenu sandwichMenu = new SandwichMenu();

sandwichMenu["blt"] = new Sandwich("wheat", "bacon", "", "lettuce");

Sandwich sandwichShallowCopy = sandwichMenu["blt"].Clone() as Sandwich;

//here i add to this and to the origial reference
sandwichShallowCopy.Cal.Add(1);


// deep copy
sandwichMenu["clt"] = new Sandwich("wheat", "bacon", "", "lettuce");

Sandwich sandwichDeepCopy = sandwichMenu["clt"].DeepCopy() as Sandwich;

sandwichDeepCopy.Cal.Add(1);
;

