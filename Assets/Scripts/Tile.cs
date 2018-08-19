using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//wrapper for a coordinate pair on the tile map
public class Tile
{
    public readonly int s, t;

    public Tile(int s, int t)
    {
        this.s = s;
        this.t = t;
    }

    public override string ToString()
    {
        return $"{s},{t}";
    }
}
