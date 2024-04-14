playableRepository interface:
- void add(Playable elem)
- void delete(int id) throws NotFoundError
- Playable? search(int id)
- Playable[] getAll() <- might suffer modifications

musictagRepository interface:
- void add(MusicTag elem)
- MusicTag? search(int id)
- MusicTag[] getAll() <- might suffer modifications

songBuilder interface:
- *should have an internal list*
- void add(Playable elem)
- void remove(Playable or int)
- Playable getList()

Service interface:
- void add(Playable elem)
- void deletePlayable(int id)
- Playable? searchPlayable(int id)
- Playable[] getAllPlayable()
- void add(MusicTag elem)
- MusicTag? searchTag(int id)
- MusicTag[] getAllTags()
- Playable create(Playable[] elements)

*Playable* file format: .wav, not .mp3


#### Niste tutoriale pentru Git:
https://git-scm.com/book/en/v2/Git-Basics-Working-with-Remotes \
https://git-scm.com/book/en/v2/Git-Branching-Branches-in-a-Nutshell \
https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging
