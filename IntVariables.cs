using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Variables/Vector2 variables")]
public class Vector2Variable : VariableGeneric<Vector2> { }


[CreateAssetMenu(menuName = "Variables/Object variables")]
public class ObjectVariable : VariableGeneric<Object> { }

[CreateAssetMenu(menuName = "Variables/GameObject variables")]
public class GameObjectVariable : VariableGeneric<GameObject> { }


