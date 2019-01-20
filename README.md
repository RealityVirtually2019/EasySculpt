<p align = "center">
    <img src="https://challengepost-s3-challengepost.netdna-ssl.com/photos/production/software_photos/000/746/471/datas/gallery.jpg" />
</p>

# Sculpt Trace
Imagine yourself learning and creating a perfect sculptures by tracing and manipulating 3D holograms in real time!

## The BIG picture (1 minute short animation):
https://www.youtube.com/watch?v=COx-A-lIOmI
Demo: https://youtu.be/l3XGK6rFCxk?t=62

## Inspiration
Humans have traced images on paper for centuries. It has been practiced since medieval times, and it is essential to artists, architects, animators, and many others who practice visual art. One member of our team is an artist and aspiring sculptor. She frequently uses 2D tracing device (light table, tracing paper, etc) in making illustrations. She and many of her classmates wished to have a 3D version of tracing device to assist sculpting. Realizing this pain point, we brainstormed together and got excited that modern mixed-reality technology could be the key to the problem!

## What it does
Now, it's time to move history to the next step. Imagine a light table or tracing paper for sculptures. With mixed reality, you can create a perfect sculpture by tracing a 3D hologram. This HoloLens application projects a 3D model onto your table for you to trace, and guides you through the sculpting process step by step starting from a basic model. You can increase the level of detail progressively. We believe this tool will be very useful in education, art practices, and for anyone creating a personal gift. You can sculpt your favorite characters or anything your passion guides you! Plus, utilizing hand gestures and voice commands, you don't have to touch your computers/book/model references with dirty hands!

## How we built it
Our team consists of 3 software students and a 2D artist/aspiring sculptor. In the first 5 hours, we focused mainly on the problem space, brainstormed the project blueprint template that we learned from the PTC workshop, and designed our user journey + UX storyboard. After having fun talking about multiple solutions and doing UX roleplaying, we prioritized and narrowed our list of features! We ranked the features based on 1. Impact, 2. Technical Challenge, 3. Art Vibe, and 4. Innovation. Then, we assigned each other tasks. Our youngest team member took the initiative to learn about 3D modeling. Our designer guided us in the UX journey and designed various components. Our two developers learned Microsoft HoloLens development on the go and turned our idea into fruition!

SDKs, APIs, free assets:
- Microsoft HoloLens & Unity 2017.4+
- HoloToolkit 2017.4.3.0
- Mesh simplifier: https://github.com/Whinarn/UnityMeshSimplifier
- MKToon Shader: https://assetstore.unity.com/packages/vfx/shaders/mk-toon-90213
- Blender 2.79b
- Mountain lion: https://free3d.com/3d-model/mountainlion-v2--107153.html
- Santa Claus: https://www.turbosquid.com/3d-models/3d-model-santa-claus-1233978?fbclid=IwAR1V7jdDIHHGUUhtdPCf0rvjoQGOXkRcZLu7Pf43wEhnnGCcnswBDKF-J50
- Rocket: - https://free3d.com/3d-model/rocket-781772.html

## Challenges we ran into
We ran into various challenges. The most frequent one is version mismatch and "breaking" changes in our application's dependencies (e.g., some require C# 4.6 experimental vs 3.5 stable, some APIs got deprecated in Unity 2018, and many more). Mixed reality development is a rapidly growing field and every new update seems to significantly alter the development process. We also ran into problems with the HoloToolkit and vuforia.

## Accomplishments 
Although we ran out of time to implement all of our desired features, we were so excited to create a minimum viable product that can guide aspiring sculptors through the process and reduce their sculpting time significantly. This MVP allowed us to ask other participants to test and quickly iterate based on their feedback. 

## Future Works:
1. In the future, we hope to successfully integrate computer vision technology to this application so that it can provide continuous feedback on the user's performance. While sculpting, you can get scored on how accurately you are following the model and can receive constructive feedback+hints to improve your skills! Sculpting is a time-consuming process that requires lots of patience and high attention to details. We believe our mixed reality application can educate a wide range of aspiring artists and spark interest in the future generation of creative sculptors!

2. Sculptors have preferences of additive process (adding material to form shape) and subtractive process (remove/carve material to form shape). Also, some materials such as wood are subtractive process, and some others are additive process. To address these user needs, we can add feature that makes object to become larger in additive process and become smaller in subtractive process.

3. We also aim to make this tool more accessible in professional art practices and education. We will investigate how to 3D scan the process of professional sculptors in addition to using computer-generated step by step instructions.
