# PerformantSpaceShooter by Joakim Karbing

I made this assignment using Unity Entities (DOTS) which optimizes the game for how computers store and process data. A bigger part of the efficiency comes from separating the data associated with an entity/object from the logic and using structs. Structs are allocated in stack, and since the stack works faster than heap using almost only structs greatly contributes to the efficiency.

The first big issue i encountered was sudden spikes in MS as great as going from steady 4ms, to ~1300ms for a frame. By using the profiler, i tracked this down to being VSYNC related and was fixed by disabling vsync.
![Profiler_Vsync_Spike](https://github.com/k4rba/PerformantSpaceShooter/assets/22280392/0a9f9628-1e4f-4a1d-befa-8ae102faa4eb)



The second issue i found was during runtime. Where the memory seemed to ocassionally nosedive to a point where the frame didnt even exist according to the profiler. However, this didnt affect performance somehow, but I still wanted to fix this.
I did some research on this, and discovered that these drops in memory are due to the garbage collector being triggered once there's enough junk in the heap. This is considered normal behavior and is the garbage collector just doing its job.
![Profiler_MemoryLoss](https://github.com/k4rba/PerformantSpaceShooter/assets/22280392/ceca03a6-34d2-49c2-9609-24268b3a6afb)





I created this project while strictly following rules provided by the Unity ECS community and the official documentation. Although there has been many optimizations happening along the way, at this point i'm not exactly sure what i can do to change the code to improve performance and prove that it actually affects anything since its already running steadily at so few ms.

Thank you for reading :)
