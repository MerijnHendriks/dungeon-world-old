# Dungeon World Notes

Written by Merijn Hendriks

## Rolls

A normal `roll` is always 2d6.  
Depending on the roll's result, you get one of the following outcomes:

**Range** | **Result**
----------| ---------
2 - 6     | Failure
7 - 9     | Partial
10 - 12   | Success

## Stats

### General

**Stat**      | **Abbr** | **Function**
------------- | -------- | ------------------------------
Level         | lvl      | `self explanitory`
Experience    | exp      | `self explanitory`
Health        | hp       | Total health
Capacity      | cap      | Maximum carry weight
Armor         | armor    | Current armor
Fail          | fail     | Amount of failed rolls
Travel ration | trvl     | Amount of allowed travel days

#### Formulas

To calculate the general stats above.

**Stat**          | **Calculation**
----------------- | ---------------------------
Max exp to lvl up | `level + 7`
Max health        | `classBaseHp + con`
Max capacity      | `classBaseCapacity (12)`
Base damage       | `classBaseDamage (1d10)`
Armor             | `all item armor combined`

#### Health

HP represents stamina, endurance, and health.  
Max health never changes unless constitution is permanently (in/de)creased.

### Attributes

Attributes cannot be lower than 1 or higher than 20.  

**Attribute** | **Abbr** | **Function**
------------- | -------- | --------------------
Strength      | str      | Handling weapons
Constitution  | con      | Healthiness
Dexterity     | dex      | Speed and athletics
Intelligence  | int      | Knowledge
Wisdon        | wis      | Common sense
Charisma      | cha      | Persuasion

#### Modifier

The modifier added to rolls of that attribute is applied depending on the attribute level:

**Range** | **Value**
--------- | ---------
3         | -3
4 - 5     | -2
6 - 8     | -1
9 - 12    |  0
13 - 15   | +1
16 - 17   | +2
18        | +3

#### Character creation

Assign these levels to attributes of your choice.  
You can only assign each level once.

- 16
- 15
- 13
- 12
- 9
- 8

## Movoe effects

**Effect**       | **Function**
---------------- | -------------------------------------------------------------------------
Deal damage      | Apply damage to target based on class dmg dice, sometimes includes weapon
Take `x` forward | Take `x` on the next move roll when condition is met
Take `x` ongoing | Take `x` on all move roles until it's dismissed
Hold             | Make a decision later based on scenario described
Choose           | Pick an option
Spout lore       | Say somthing about the character or world
Mark XP          | Add 1 EXP to your total EXP

## Actions

These can be done under various scenarios.

### Make camp

**Property** | **Value**
------------ | --------------------------------------------
Cost         | 1 `trvl`
Conditions   | Outside combat

```unformatted
Rest
```

### Hack & Slash

**Property** | **Value**
------------ | ---------------------------------------------------
Type         | Melee attack
Cost         | None
Conditions   | Close range, Target, Enemy must be ready for combat

```unformatted
damage = physical (classBaseDamage + bonus)
result = roll + (weapon == precise) ? dex : str
doDamage = (partial || success) ? true : false

if (success)
   choose
   1: "attack with normal damage and dodge"
   2: "attack with extra damage"

for (enemies)
    if (inRange && doDamage && !physicalResistant)
        enemy -= damage

    if (success option 2)
        enemy -= 1d6

if (failure || partial || success option 2)
    enemy (target) attacks
```
