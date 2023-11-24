#!/bin/sh

total_exercises=0
completed_exercises=0

for track_dir in */; do
    for exercise_dir in "$track_dir"*/; do
        total_exercises=$((total_exercises + 1))

        track_name=${track_dir%/}
        exercise_name=${exercise_dir%/}

        echo "Downloading track '$track_name' exercise '$exercise_name'..."

        exercism download --track="$track_name" --exercise="$exercise_name" --force

        completed_exercises=$((completed_exercises + 1))

        update_progress_bar
    done
done

echo ""
echo "All exercises downloaded successfully!"

function update_progress_bar {
    progress=$((completed_exercises * 100 / total_exercises))
    bar_length=50
    filled_portion=$((bar_length * progress / 100))
    empty_portion=$((bar_length - filled_portion))

    printf "\r[%-${bar_length}s] %3d%%" "${filled_portion// /#}" "$progress"
}
