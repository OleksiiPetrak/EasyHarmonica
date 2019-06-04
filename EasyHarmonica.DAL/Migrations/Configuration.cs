using EasyHarmonica.Common.Enums;
using EasyHarmonica.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.EasyHarmonicaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EF.EasyHarmonicaContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name,
               new Role { Name = "Administrator" },
               new Role { Name = "User" },
               new Role { Name = "Manager" },
               new Role { Name = "Moderator" },
               new Role { Name = "Guest" }
               );

            context.SaveChanges();

            var roleUser = context.Roles.FirstOrDefault(x => x.Name == "User");
            var roleManager = context.Roles.FirstOrDefault(x => x.Name == "Manager");
            var roleAdmin = context.Roles.FirstOrDefault(x => x.Name == "Administrator");
            var roleModerator = context.Roles.FirstOrDefault(x => x.Name == "Moderator");

            context.Users.AddOrUpdate(x => x.Email,
                new User { PasswordHash = "password".GetHashCode().ToString(), UserName = "h.levy@mail.com", Email = "h.levy@mail.com" },
                new User { PasswordHash = "password".GetHashCode().ToString(), UserName = "petrak@mail.com", Email = "petrak@mail.com" },
                new User { PasswordHash = "password".GetHashCode().ToString(), UserName = "loma@mail.com", Email = "loma@mail.com" });

            context.SaveChanges();

            var howardLevy = context.Users.FirstOrDefault(x => x.Email == "h.levy@mail.com");
            var oleksiiPetrak = context.Users.FirstOrDefault(x => x.Email == "petrak@mail.com");
            var lomachenko = context.Users.FirstOrDefault(x => x.Email == "loma@mail.com");

            context.Users.AddOrUpdate(x => x.Email,
                new User
                {
                    PasswordHash = "password".GetHashCode().ToString(),
                    UserName = "h.levy@mail.com",
                    Email = "h.levy@mail.com",
                    Roles = { new IdentityUserRole { RoleId = roleManager.Id, UserId = howardLevy.Id } }
                },
                new User
                {
                    PasswordHash = "password".GetHashCode().ToString(),
                    UserName = "petrak@mail.com",
                    Email = "petrak@mail.com",
                    Roles = { new IdentityUserRole { RoleId = roleAdmin.Id, UserId = oleksiiPetrak.Id } }
                },
                new User
                {
                    PasswordHash = "password".GetHashCode().ToString(),
                    UserName = "loma@mail.com",
                    Email = "loma@mail.com",
                    Roles = { new IdentityUserRole { RoleId = roleUser.Id, UserId = lomachenko.Id } }
                });


            context.SaveChanges();

            context.ClientProfiles.AddOrUpdate(x => x.Address,
                new ClientProfile { Name = "Howard Levy", Address = "h.levy@mail.com", BirthDay = DateTime.Now.AddYears(-48), City = "LA", CourseComplexity = CourseComplexity.Hard, User = howardLevy, Registration = DateTime.Now.AddDays(-15), Progress = 30 },
                new ClientProfile { Name = "Oleksii Petrak", Address = "petrak@mail.com", BirthDay = DateTime.Now.AddYears(-21), City = "Kharkiv", CourseComplexity = CourseComplexity.Middle, User = oleksiiPetrak, Registration = DateTime.Now.AddDays(-30), Progress = 70 },
                new ClientProfile { Name = "Vasiliy Lomachenko", Address = "loma@mail.com", BirthDay = DateTime.Now.AddYears(-26), City = "Kyiv", CourseComplexity = CourseComplexity.Easy, User = lomachenko, Registration = DateTime.Now.AddDays(-7), Progress = 15 });

            context.Notifications.AddOrUpdate(x => x.Date,
                new Notification { Date = DateTime.Now.AddMinutes(15), Info = "Don't forget to practice!", Users = new List<User> { lomachenko } },
                new Notification { Date = DateTime.Now.AddMinutes(30), Info = "You lost your time!", Users = new List<User> { lomachenko } },
                new Notification { Date = DateTime.Now.AddMinutes(60), Info = "New chapter is available!", Users = new List<User> { lomachenko } });

            context.Chapters.AddOrUpdate(x => x.Name,
                new Chapter { Info = "Chapter contain basic knowledge for future harper", Name = "Start" },
                new Chapter { Info = "Chapter contain key knowledge for frequent play", Name = "Essential" },
                new Chapter
                {
                    Info = "Chapter contain additional knowledge for professional musician",
                    Name = "Experience"
                });

            context.SaveChanges();

            var startChapter = context.Chapters.FirstOrDefault(x => x.Name == "Start");

            context.Lessons.AddOrUpdate(x => x.Name,
                new Lesson
                {
                    Name = "How to choice a harmonica",
                    Info = @"In this article we will tell you how to choose and buy a good harmonica. Unfortunately,
                    more than 89 % of all manufacturers of harmonicas(including German) produce not only professional,
                    but also more educational materials.

                    A person never rejects the desire to master this tool.Unfortunately,
                    with tacit collusion,
                    it remains to “stamp” a poor - quality product,
                    since it is he who brings him the highest profit.That is why the harmonica remains such a rare problem and needs to be popularized.

                    It is in professional harmonists, in popularization of this instrument and in enthusiasts that the main function of informing all novice harmonists lies on how to choose and buy a harmonica,
                    whether to learn to play,
                    and how not to make a wrong choice,
                    because there are so many in music stores lip harmonicas.

                    In fact,
                    good harmonicas can be listed on the fingers.This article lists all the good models of harmonicas that must learn to play for everyone.

                    List of good harmonicas:
                        By the way, recalls that the Latin letter C).

                    Easttop T008K
                    Honer Golden Melody
                    Hohner special 20
                    Hohner rocket
                    Seidel 1847
                    Seidel Session Steel
                    Hohner Marine Band Crossover
                    Hohner Marine Band Deluxe
                    Suzuki Olive
                    Suzuki manji
                    Many people think that you can choose and buy a mouth organ of good quality for a start. People are completely disappointed in this instrument after playing low - quality harmonica.

                    First of all, we want you to understand the types of mouth organ harmonicas, so that, perhaps, harmonics of different sizes and types were involved in them.Lip harmonicas are really different: diatonic(10 - hole), chromatic harmonicas, tremolo, octave, bass, chord harmonicas, as well as hybrids of these harmonicas.How can you still choose and buy a harmonica ? Octave, bass and chord mouth harmonics are most often used in accordion orchestras, and most likely they will not be sold in your country.Let's talk about diatonic, chromatic harmonic and harmonica tremolo, and how to choose a harmonica.

                    Tremolo lip harmonics.
                    In these harmonicas, all are frustrated with two sound languages ​​relative to each other, thus achieving the tremolo effect.On such harmonica there are only white keys.This harmonica is quite primitive. She is very limited. You can only play in Russian and Ukrainian folk songs, well, and, perhaps, some other oddities - and, unfortunately, everything.

                    Chromatic harmonic harmonics - on the contrary, they have all the sounds of the chromatic scale.On chromatic lip harmonicas, as a rule, you can play complex classical works, jazz music, and here you need to have a good musical education, read notes “from the sheet” and have good training in diatonic harmonica.Almost all harmonics playing on chromatic lip harmonics, starting with diatonic harmonics, as well as some of them and skills, such as beautiful vibrato or bends(which theoretically cannot be done on chromatic lip harmonics, which are usually practiced constantly) can be fine - tuned.on the diatonic harmonica, without damaging the instrument tongues.",
                    Tuner = "http://modusmusic.ru/info/hromaticheskiy-tyuner-dlja-nastrojki-muzykalnyh-instrumentov/",
                    ChapterId = startChapter.Id,
                    Users = new List<User> { lomachenko },
                    Duration = new TimeSpan(0,0,0,0)
                },
                new Lesson
                {
                    Name = "How to take clear note",
                    Info = @"Watch the first part of this video “How to learn to play the harmonica from scratch”, and also get the TOP 5 accompaniments for a harmonica.

In this article (below) you will find all the necessary materials to learn how to play the harmonica: with detailed audio examples, tasks and exercises.


How to learn to play the harmonica with single notes:
Proper sound extraction (three rules of good sound: muscle, camera, breathing)
The rounded hole formed by the lips, as opposed to the oblong.
Formation of a relaxed and directed air jet (as when pronouncing the letter “O”), as opposed to strong and diffuse (as when blowing and sucking air)

Critical errors when teaching the game with single notes:
The opening of the lips is not rounded but oblong.
The muscles of the face and, in particular, the lips are too tense.
Air blowing and suction instead of proper breathing.
Tip!
If you still do not play single notes, try tilting the harmonica slightly upwards. In some miraculous way this advice helps many students.

If you find it difficult to learn how to play single notes on your own, then we recommend registering for our free 15-day online QUICK START course, where we will help you master all the basic skills of a accordionist: breathe properly, play single notes and perform compositions on tabulation to the accompaniment.

Exercises
Exercise 1.
Purpose:
Learn to play single notes so as not to hurt the neighboring holes, as well as smoothly move from one hole to another, without diverting the harmonica from the lips.

The task:
Play single notes on the holes indicated:

+ 4-4.

Exercise 2.
Purpose:
Learn to apply the 3 fundamental rules of beautiful sound in the context of the game with single notes and play each note “from quiet to medium” as beautifully and gently as possible.

The task:
Play the C major scale + 4-4 + 5-5 + 6-6-7 + 7, using the 3 rules of high-quality sound and outputting each note “from quiet to medium”.

Exercise 3.
Purpose:
Focus on the melody, but at the same time try to play every note perfectly “purely”, without touching the neighboring holes.

The task:
Play one or more tunes from the list (below), playing very slowly (2 or even 3 times slower than the audio example).

Exercise 4.
Purpose:
begin to apply the 3 basic rules of beautiful sound in the context of the game you learned melodies.

The task:
Play the melody you learned very slowly with long notes, outputting every note from quiet to loud, focusing attention on the correct implementation of the three basic rules.
",
                    Tuner = "http://modusmusic.ru/info/hromaticheskiy-tyuner-dlja-nastrojki-muzykalnyh-instrumentov/",
                    ChapterId = startChapter.Id,
                    Users = new List<User> { lomachenko },
                    Duration = new TimeSpan(0, 23, 0, 0)
                },
                new Lesson
                {
                    Name = "How to play bends",
                    Info = @"The harmonica bend is a technique for lowering the pitch of a note.

Bends can not only get a new note on one of the holes of the harmonica, but also are able to make the melody on the harmonica smoother, flowing from note to note. And this is the most wonderful opportunity of this instrument, for which the harmonica has by any means better come up in the blues, where the tightening and bending of notes, as well as the smooth flow of one note into another, causes listeners to become covered with goose bumps.

A smooth flow from one note to another using well-developed bands is something that can be played on a harmonica, but it is impossible to do, for example, a piano.

There are bands on the harmonica, both inhale and exhale.
By inhaling, bends on a harmonica can be made on the first six holes except the fifth. Attempts to make a bend on the fifth hole can break the tongue on the harmonica, so try not to make mistakes with the holes so as not to break your instrument.
On the exhalation of the band exist from the eighth to the tenth hole of the harmonica.


The most commonly used bands to inhale. From them and should start learning this technique.
At first it will seem to you that the bend on one hole is very different from the band on the other hole. At the beginning of the practice, this difference is very noticeable. Don't let that scare you. As you improve this harmonica skill, these differences will begin to blur and become insignificant.

When you are just starting to try your first harmonica band, make more attempts. In the beginning, take not quality, but quantity. For one breath - one attempt, and do not take this breath long. We tried, if it didn't work out, then we breathed out - and drove on. Every time try to change something in the oral cavity, larynx, position of the tongue - do not be afraid to experiment. If it does not work, and you are trying to repeat the same thing all the time, without changing anything, it’s like stepping on the same rake. If it does not work, then the minimum is something changed - and try again.

As soon as you heard that the harmonica note was a little bit, but it went down - try to repeat the same thing right away. You shouldn’t stop and try to realize “what combination we made in the mouth and in which knot weighed a tongue” - you probably won't be able to understand what you did there. Here it is necessary to turn off the head and do-do-do. Immediately repeat success without thinking - easy enough! If, after the first successful attempt, you are thinking and consciously trying to build a combination in the mouth, it will not work. That's when you make 30-50 times, even if shallow bands, most of which were obtained, then you can gradually begin to realize what you have done in your mouth. But by this time, your body will already remember the minimum skill of doing a bend on a harmonica, and this skill is “not to be drunk”. In general, at first do not hesitate and make the most of the law of the Universe, which says that “beginners and fools are lucky”! (we are about the first).

But then work will begin on the quality of your bend on the harmonica.Here you will need both the “included” brain,
                    and attentive hearing,
                    and it will be important to notice all the changes that you make with your body.Because as a result,
                    you need to learn at each bend opening of the harmonica to smoothly lower the note to the very bottom,
                    then returning to a clean note.At the same time try to do it as slowly as possible, and your muscles will gain good control over the bends. Ensure that at each moment of time the sound does not disappear, does not break, does not fall through and does not tremble.

Very often, during the “search” for the harmonica bands, the beginning harmonists are overly stressed.This, unfortunately, cannot be avoided, but you must remember that you should not overstrain the muscles of the throat.This, on the contrary, can interfere with the lowering deeper, lowering the note.If you compare your bend with the audio file of our self - help textbook on the harmonica and understand that you can’t get to the bottom at all - pay attention to the throat muscles and try to relax them.By the way, many students, who are just starting to learn to make bends, state that if before that they used a little alcohol(A LITTLE !!!), then for some reason, bends immediately become easier.Often this is true, because it is the excessive tension of all the muscles involved and even not participating in the lowering of the harmonica notes that make it difficult to achieve a good band.And after taking a small dose of alcohol muscle tone decreases, you relax, both physically and psychologically - and some breaks into the band.Just do not take this for advice!


Throughout the study of bends, you must remember the following rules, which are valid for all bands to inhale:

One of the most important variables involved in creating the band is the size of the resonator chamber in our body.
The second important variable is air pressure (in our case it is negative pressure, that is, we need to inhale more (as if we want to play a little louder) BUT DO NOT SUCK UP!
In addition, the air flow during inhalation should be dense and continuous.
Muscles of the throat can not be clamped. They may be a bit toned, but not compressed. And the more it is impossible to completely or almost completely clamp the glottis.
It is impossible to breathe air in parallel with the nose, and also make sure that there are no gaps between the lips and the harmonica, through which additional air could flow.
We remind you that the breathable bands on the harmonica exist on the first six holes except the fifth one. On the second hole, you can lower the note by two semitones, on the third - by three semitones, and on all others (on the first, fourth and sixth holes) - only half a tone.
The lower the note (the extreme case is the first hole), the more important is the size of the resonator chamber (the entire resonator chamber that participates here is two natural resonators: the head and the lungs, and the additional resonator is a chamber in the mouth.)

The higher the note (the extreme case is the sixth hole), the camera size loses its importance and, on the contrary, even decreases, but the work of the language becomes more important.

We recommend that you start exploring the harmonica band with holes, where you can only lower notes by half a tone (1, 4 and 6). Having learned to make bends on these holes, it will be easier for you to move on to mastering bends on the second and third holes of the harmonica.

Bend on the first opening of the harmonica.

As we mentioned, the size of the camera is of great importance here. Moreover, it is not just necessary to increase the camera in the mouth, but it is necessary to “lengthen” it a little down the body - open the larynx as much as possible with a relaxed throat and imagine that the mouth and the lower part of the lungs are connected by a wide tube inside which the air moves.
Remember how you yawn with your mouth closed: the soft and hard palate rises, the larynx opens, you get the feeling that the air even goes down your throat and you feel a slight tension in the solar plexus. Try to move the same yawn with your mouth closed in the context of an attempt to make a bend on the first opening of the harmonica to inhale. In this case, remember all the above rules.

Bend on the sixth mouth of the harmonica.

The bend at the sixth mouth of the harmonica is another extreme case where to create the bend you need to find the right movement of the tongue, and the oral cavity chamber decreases.
Try to inhale quickly enough to pronounce the syllables of the yo-yo-yo-yo, exaggeratingly moving the tongue. You will surely hear how the pitch changes. Note that it is on the sound of the “nd” note that is lower than on the “o”. Now you need to practice so that you can keep this lowered note, which is the band on the sixth hole. Check the pitch of the note with the audio file below so that you accurately “reach out” the band to the very bottom.

All other bands: on the fourth, second and third holes - is a combination of the work of the tongue and resizing the chamber of the oral cavity, provided that all the listed rules, which are described at the beginning of this article, are followed.

At the third opening of the harmonica, you can lower the note by three semitones. For many, this is the most difficult bend hole. In addition, after you learn to smoothly lower the note to the very bottom, you will need to learn how to take intermediate bends on the third opening of the harmonica.
",
                    Tuner = "http://modusmusic.ru/info/hromaticheskiy-tyuner-dlja-nastrojki-muzykalnyh-instrumentov/",
                    ChapterId = startChapter.Id,
                    Users = new List<User> { lomachenko },
                    Duration = new TimeSpan(0, 15, 0, 0)
                });

            context.SaveChanges();

            var clearNote = context.Lessons.First(x => x.Name == "How to take clear note");
            var accord = context.Lessons.First(x => x.Name == "How to play bends");

            context.Achievements.AddOrUpdate(x => x.Name,
                new Achievement { Name = "Fast learner", Users = new List<User> { lomachenko }, LessonId = clearNote.Id },
                new Achievement { Name = "Talent!", Users = new List<User> { lomachenko }, LessonId = accord.Id },
                new Achievement { Name = "All in time", Users = new List<User> { lomachenko }, LessonId = accord.Id });

        }
    }
}
