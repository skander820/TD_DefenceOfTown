using UnityEngine;
public class PathManager{
    public static Transform[] path;
    public static Transform[] getPath(){
        path = WayPoints.positions ;

        return path;
    }


}