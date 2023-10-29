# PerformantSpaceShooter

I made this assignment using Unity Entities (DOTS) which optimizes the game for how computers store and process data. The efficiency comes from separating the data associated with an entity/object from the logic. Structs are allocated in stack, and since the stack works faster than heap using almost only structs also contributes to the efficiency. I tested the project pre-final build where i had over 100.000 entities moving at the same time with barely any difference in performance which is amazing.


The first big issue i encountered was sudden spikes in MS as great as going from steady 4ms, to ~1300ms for a frame. By using the profiler, i tracked this down to being VSYNC related and was fixed by disabling vsync.
![Profiler_Vsync_Spike](https://github.com/k4rba/PerformantSpaceShooter/assets/22280392/0a9f9628-1e4f-4a1d-befa-8ae102faa4eb)



The second issue i found was during runtime. Where the memory seemed to ocassionally nosedive to a point where the frame didnt even exist according to the profiler. However, this didnt affect performance somehow, but I still wanted to fix this.
I did some research on this, and discovered that these drops in memory are due to the garbage collector being triggered once there's enough junk in the heap. This is considered normal behavior and is the garbage collector just doing its job.
![Profiler_MemoryLoss](https://github.com/k4rba/PerformantSpaceShooter/assets/22280392/ceca03a6-34d2-49c2-9609-24268b3a6afb)

Thats about it! :)
