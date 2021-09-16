// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

/**
 * Removes duplicate tracks from a playlist.
 *
 * @param {string[]} playlist
 * @returns {string[]} new playlist with unique entries
 */
export function removeDuplicates(playlist) {
  let set = new Set(playlist);
  let values = set.values();
  return Array.from(values);
}

/**
 * Checks whether a playlist includes a track.
 *
 * @param {string[]} playlist
 * @param {string} track
 * @returns {boolean} whether the track is in the playlist
 */
export function hasTrack(playlist, track) {
  return playlist.findIndex(value => track === value) >= 0;
}

/**
 * Adds a track to a playlist.
 *
 * @param {string[]} playlist
 * @param {string} track
 * @returns {string[]} new playlist
 */
export function addTrack(playlist, track) {
  const newPlaylist =  Array.from(playlist);

  if (!hasTrack(playlist, track)){
    newPlaylist.push(track);
  }

  return newPlaylist;
}

/**
 * Deletes a track from a playlist.
 *
 * @param {string[]} playlist
 * @param {string} track
 * @returns {string[]} new playlist
 */
export function deleteTrack(playlist, track) {
  const newPlaylist =  Array.from(playlist);

  if (!hasTrack(playlist, track)){
    newPlaylist.push(track);
  }

  const index = playlist.findIndex(value => track === value);
  newPlaylist.splice(index, 1);
  
  return newPlaylist;
}

/**
 * Lists the unique artists in a playlist.
 *
 * @param {string[]} playlist
 * @returns {string[]} list of artists
 */
export function listArtists(playlist) {
  const artists =  playlist.map(track => track.split(" - ")[1]);

  return removeDuplicates(artists);
}
