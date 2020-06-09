# Alesis VI49 Templater

### DISCLAIMER
Use it on your own risk. I don't responsible for any consequences of using this software.
I wrote it for my own usage, but feel free to make PR or report issues.

## Why you may need this app?

You have alesis vi49 keyboard and a preset that you want to duplicate, but using different midi channels.

## How to use this app?

1. Make sure you have netcore runtime 3.1
2. Clone this repo
3. Go to `build` directory
4. Open console (shift+right click -> open powershell)
5. Run `AlesisTemplater.Console.exe {path_to_your_template.vi49}`

Presets for all 16 midi channels will be generater in the directory.

## Additional content

I added my own presets that I use to power Ableton Live. There are two of them: `master.vi49` and `individuals.vi49`.

![Alesis](https://github.com/nzhulikov/alesis-templater/raw/master/alesis_vi49.png)

### Master

It works with midi channels from 1 to 12.
**CH01** is mix bus:
- Knob 1 controls master volume
- Switch 1 starts playback
- Switch 13 stops playback
- Switch 25 is free
- Drum pads are CC for playing master clips

**CH02-12** are for individual tracks.
- Knobs 2 - 12 controls track's volumes
- Switches 2-12 play current clip
- Switches 14-24 stop playing clips
- Switches 25-36 power track for record

### Individuals

Each one works on it's MIDI channel.

- Knob 1 controls volume
- Knob 2 controls pan
- Switch 12 plays current clip
- Switch 24 stops track
- Switch 36 power track for record
- Switches 1-11 for playing clips
- Other switches (13-23 are momentary, 25-35 are toggle) for situational use
