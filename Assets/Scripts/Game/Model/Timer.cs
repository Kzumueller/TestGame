using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Timer {

    private float time;

    public Timer(float time) {
        this.time = time;
    }

    public bool Finished(float deltaTime) {
        time -= deltaTime;

        return 0 >= time;
    }
}
