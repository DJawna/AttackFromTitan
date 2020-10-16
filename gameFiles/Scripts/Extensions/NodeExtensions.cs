using System;
using Godot;

namespace AttackFromTitan.Extensions {

    static class NodeExtensions{
        public static bool TryGetFirstChild<NodeType>(this Node Parent, out NodeType matchingChild, Func<NodeType,bool> predicate) where NodeType : Node{
            foreach(var child in Parent.GetChildren()){
                var candidate = child as NodeType;
                if(candidate != null && predicate(candidate)){
                    matchingChild = candidate;
                    return true;
                }
            }
            matchingChild = null;
            return false;
        }
    }
}